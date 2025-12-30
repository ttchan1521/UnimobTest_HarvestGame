using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryHarvestingState : DeliveryState
{
    private PlantController _plantController;
    private DeliveryController _deliveryController;
    private float _harvestTimer = 0f;
    private List<FruitEntity> _fruitEntities;
    private Transform[] _targetPoints;
    private Vector3[] _startPositions;


    public DeliveryHarvestingState(DeliveryController deliveryController, PlantController plantController) : base(deliveryController)
    {
        _plantController = plantController;
        _deliveryController = deliveryController;
    }

    public override void Dispose()
    {
        GameManager.Instance.timer.TICK -= OnTick;
    }

    public override void Initialize()
    {
        _fruitEntities = _plantController.PlantEntity.fruitEntities;
        _targetPoints = _deliveryController.CharacterEntity.carryPoints;
        _startPositions = new Vector3[_fruitEntities.Count];
        for (int i = 0; i < _fruitEntities.Count; i++)
        {
            _startPositions[i] = _fruitEntities[i].transform.position;
        }

        GameManager.Instance.timer.TICK += OnTick;

    }

    private void OnTick()
    {
        _harvestTimer += Time.deltaTime;
        float t = _harvestTimer / 0.6f;
        t = Mathf.Clamp01(t);

        for (int i = 0; i < _fruitEntities.Count && i < _targetPoints.Length; i++)
        {
            _fruitEntities[i].transform.position = TransformExtension.MoveAlongArc(
                _startPositions[i],
                _targetPoints[i].position,
                t,
                1f // arc height
            );
        }

        if (t >= 1f)
        {
            OnHarvestComplete();
        }
    }

    public void OnHarvestComplete()
    {
        
    }
}
