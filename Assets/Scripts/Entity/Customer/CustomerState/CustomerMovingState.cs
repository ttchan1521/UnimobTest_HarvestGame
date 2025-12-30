using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

public class CustomerMovingState : CustomerState
{
    private CustomerController _customerController;
    private Vector3 _marketPos;
    private bool _isRotateingToMarket = false;

    public CustomerMovingState(CustomerController customerController, Vector3 marketPos) : base(customerController)
    {
        _customerController = customerController;
        _marketPos = marketPos;
    }

    public override void Dispose()
    {
        GameManager.Instance.timer.TICK -= OnTick;
    }

    public override void Initialize()
    {
        _isRotateingToMarket = false;
        GameManager.Instance.timer.TICK += OnTick;
        _customerController.CustomerEntity.PlayAnimMove();
    }

    private void OnTick()
    {
        var currentPos = _customerController.CustomerEntity.transform.position;

        // Nếu đang xoay về plant thì chỉ xoay
        if (_isRotateingToMarket)
        {
            RotateToMarket();
            return;
        }

        // Calculate direction
        Vector3 direction = (_marketPos - currentPos).normalized;

        // Rotate towards target
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            _customerController.CustomerEntity.transform.rotation = Quaternion.Slerp(
                _customerController.CustomerEntity.transform.rotation,
                targetRotation,
                10f * Time.deltaTime
            );
        }

        var newPosition = Vector3.MoveTowards(
            currentPos,
            _marketPos,
            6f * Time.deltaTime
        );

        _customerController.CustomerEntity.Move(newPosition);
        // Check if reached destination
        if (Vector3.Distance(newPosition, _marketPos) < 0.1f)
        {
            _isRotateingToMarket = true;
        }
    }

    private void RotateToMarket()
    {
        _customerController.CustomerEntity.PlayAnimIdle();

        // Xoay về phía trục Z = -1
        Vector3 targetDirection = new Vector3(0, 0, -1);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        _customerController.CustomerEntity.transform.rotation = Quaternion.Slerp(
            _customerController.CustomerEntity.transform.rotation,
            targetRotation,
            8f * Time.deltaTime
        );

        // Kiểm tra đã xoay xong chưa
        float angle = Quaternion.Angle(_customerController.CustomerEntity.transform.rotation, targetRotation);
        if (angle < 1f)
        {
            OnReachedMarket();
        }
    }

    private void OnReachedMarket()
    {
        
    }
}

    
