using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowingState : PlantState
{
    private PlantController _plantController;
    private float _currentTime;
    private List<FruitEntity> _fruitEntities;

    public PlantGrowingState(PlantController plantController) : base(plantController)
    {
        _plantController = plantController;
    }

    public override void Dispose()
    {
        GameManager.Instance.timer.TICK -= OnTick;
    }

    public override void Initialize()
    {
        _fruitEntities = _plantController.PlantEntity.SpawnFruit(3);
        for (int i = 0; i < _fruitEntities.Count; i++)
        {
            _fruitEntities[i].SetScale(0f);
        }

        _currentTime = 0;

        GameManager.Instance.timer.TICK += OnTick;
    }

    private void OnTick()
    {
        _currentTime += Time.deltaTime;
        var harvestTime = _plantController.PlantModel.levels[
            _plantController.PlantModel.currentLevel
        ].harvestTime;
        
        if (_currentTime < 0.3f * harvestTime)
        {
            return;
        }

        float growProgress = 
            (_currentTime - 0.3f * harvestTime) / (0.7f * harvestTime);
        growProgress = Mathf.Clamp01(growProgress);
        
        foreach (var fruit in _fruitEntities)
        {
            fruit.SetScale(growProgress);
        }

        if (_currentTime >= harvestTime)
        {
            OnGrowthComplete();
        }
    }

    private void OnGrowthComplete()
    {
        _plantController.SwitchToState(
            new PlantHarvestableState(_plantController)
        );
    }
}
