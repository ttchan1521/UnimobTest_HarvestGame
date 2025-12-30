using System.Collections;
using System.Collections.Generic;
using Core;
using Game.Config;
using Game.Core;
using UnityEngine;

public class BoxController : Observable<BoxController>
{
    private StateManager<BoxState> _stateManager;
    private BoxEntity _boxEntity;
    private BoxModel _boxModel;

    public BoxEntity BoxEntity => _boxEntity;
    public BoxModel BoxModel => _boxModel;

    protected override BoxController Value => this;

    public BoxController(BoxEntity boxEntity, BoxConfig boxConfig, PlantConfig plantConfig)
    {
        _boxEntity = boxEntity;
        _boxModel = new BoxModel(boxConfig, plantConfig);
        _stateManager = new StateManager<BoxState>();

        _stateManager.SwitchToState(new BoxIdleState(this));
    }

    public void SwitchToState<T>(T instance) where T : BoxState
    {
        _stateManager.SwitchToState(instance);
    }

    public void OnClick()
    {
        _stateManager.Current.OnClick();
    }
}

public class BoxModel
{
    public int cost;
    public float buildingTime;
    public Sprite plantIcon;
    public string plantName;
    public bool plantable;
    public int plantId;

    public BoxModel(BoxConfig boxConfig, PlantConfig plantConfig)
    {
        cost = boxConfig.cost;
        buildingTime = boxConfig.buildingTime;
        plantIcon = plantConfig.icon;
        plantName = plantConfig.plantName;
        plantable = false;
        plantId = plantConfig.id;
    }
}
