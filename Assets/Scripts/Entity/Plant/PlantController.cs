using System.Collections;
using System.Collections.Generic;
using Core;
using Game.Config;
using Game.Core;
using UnityEngine;

public class PlantController : Observable<PlantController>
{
    private StateManager<PlantState> _stateManager;
    private PlantEntity _plantEntity;
    private PlantModel _plantModel;

    public PlantEntity PlantEntity => _plantEntity;
    public PlantModel PlantModel => _plantModel;

    public PlantController(PlantEntity plantEntity, PlantConfig plantConfig)
    {
        _plantEntity = plantEntity;
        _plantModel = new PlantModel(plantConfig);
        _stateManager = new StateManager<PlantState>();

        SwitchToState(new PlantGrowingState(this));
    }

    protected override PlantController Value => this;

    public void SwitchToState<T>(T instance) where T : PlantState
    {
        _stateManager.SwitchToState(instance);
    }
}

public class PlantModel
{
    public string plantName;
    public Sprite icon;
    public PlantLevel[] levels;
    public int currentLevel;
    public bool harvestable;

    public PlantModel(PlantConfig config)
    {
        plantName = config.plantName;
        icon = config.icon;
        levels = config.levels;
        currentLevel = 0;
        harvestable = false;
    }
}
