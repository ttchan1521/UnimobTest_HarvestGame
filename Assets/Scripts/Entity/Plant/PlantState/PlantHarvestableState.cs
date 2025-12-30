using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHarvestableState : PlantState
{
    private PlantController _plantController;

    public PlantHarvestableState(PlantController plantController)
        : base(plantController)
    {
        _plantController = plantController;
    }

    public override void Dispose()
    {
        
    }

    public override void Initialize()
    {
        _plantController.PlantModel.harvestable = true;
        _plantController.SetChanged();
    }
}
