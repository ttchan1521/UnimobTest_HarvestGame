using System.Collections;
using System.Collections.Generic;
using Core;
using Game.Core;
using UnityEngine;

public class CustomerController : Observable<CustomerController>
{
    private StateManager<CustomerState> _stateManager;
    private CustomerModel _model;
    private CharacterEntity _customerEntity;

    public CustomerModel CustomerModel => _model;
    public CharacterEntity CustomerEntity => _customerEntity;
    
    public CustomerController(CharacterEntity customerEntity, Vector3 marketPos)
    {
        _stateManager = new StateManager<CustomerState>();
        _customerEntity = customerEntity;
        _model = new CustomerModel();

        _stateManager.SwitchToState(new CustomerMovingState(this, marketPos));
    }

    protected override CustomerController Value => this;
}

public class CustomerModel
{
    public bool isWaiting;

    public CustomerModel()
    {
        isWaiting = false;
    }
}
