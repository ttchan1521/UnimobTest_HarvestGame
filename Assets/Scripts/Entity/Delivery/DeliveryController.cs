using System.Collections;
using System.Collections.Generic;
using Game.Core;
using UnityEngine;

public class DeliveryController
{
    private StateManager<DeliveryState> _stateManager;

    private CharacterEntity _characterEntity;
    private DeliveryModel _deliveryModel;

    public CharacterEntity CharacterEntity => _characterEntity;
    public DeliveryModel DeliveryModel => _deliveryModel;
    
    public DeliveryController(CharacterEntity characterEntity, PlantController plantController)
    {
        _characterEntity = characterEntity;
        _stateManager = new StateManager<DeliveryState>();
        _deliveryModel = new DeliveryModel();

        SwitchToState(new DeliveryMoveToPlantState(this, plantController));
    }

    public void SwitchToState<T>(T instance) where T : DeliveryState
    {
        _stateManager.SwitchToState(instance);
    }
}

public class DeliveryModel
{
    public bool isHarvested;

    public DeliveryModel()
    {
        isHarvested = false;
    }
}
