using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryMoveToPlantState : DeliveryState
{
    private PlantController _plantController;
    private DeliveryController _deliveryController;
    private bool _isRotatingToPlant = false;

    public DeliveryMoveToPlantState(DeliveryController deliveryController, PlantController plantController)
        : base(deliveryController)
    {
        _deliveryController = deliveryController;
        _plantController = plantController;
    }

    public override void Dispose()
    {
        GameManager.Instance.timer.TICK -= OnTick;
    }

    public override void Initialize()
    {
        _isRotatingToPlant = false;
        GameManager.Instance.timer.TICK += OnTick;
        _deliveryController.CharacterEntity.PlayAnimMove();
        _plantController.SwitchToState(new PlantHarvestingState(_plantController));
    }

    private void OnTick()
    {
        var currentPos = _deliveryController.CharacterEntity.transform.position;
        var targetPos = _plantController.PlantEntity.deliveryPoint.position;

        // Nếu đang xoay về plant thì chỉ xoay
        if (_isRotatingToPlant)
        {
            RotateToPlant();
            return;
        }

        // Calculate direction
        Vector3 direction = (targetPos - currentPos).normalized;

        // Rotate towards target
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _deliveryController.CharacterEntity.transform.rotation = Quaternion.Slerp(
                _deliveryController.CharacterEntity.transform.rotation,
                targetRotation,
                10f * Time.deltaTime
            );
        }

        var newPosition = Vector3.MoveTowards(
            currentPos,
            targetPos,
            6f * Time.deltaTime
        );

        _deliveryController.CharacterEntity.Move(newPosition);

        // Check if reached destination
        if (Vector3.Distance(newPosition, targetPos) < 0.1f)
        {
            _isRotatingToPlant = true;
        }
    }

    private void RotateToPlant()
    {
        _deliveryController.CharacterEntity.PlayAnimIdle();
        Vector3 plantDirection = (_plantController.PlantEntity.transform.position -
                                 _deliveryController.CharacterEntity.transform.position).normalized;

        if (plantDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(plantDirection);
            _deliveryController.CharacterEntity.transform.rotation = Quaternion.Slerp(
                _deliveryController.CharacterEntity.transform.rotation,
                targetRotation,
                8f * Time.deltaTime
            );

            // Kiểm tra đã xoay xong chưa
            float angle = Quaternion.Angle(_deliveryController.CharacterEntity.transform.rotation, targetRotation);
            if (angle < 1f)
            {
                OnReachedPlant();
            }
        }
    }

    private void OnReachedPlant()
    {
        _deliveryController.SwitchToState(
            new DeliveryHarvestingState(_deliveryController, _plantController));
    }
}
