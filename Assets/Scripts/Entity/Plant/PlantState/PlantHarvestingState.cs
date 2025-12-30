using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantHarvestingState : PlantState
{
    private PlantController _plantController;
    public PlantHarvestingState(PlantController plantController) : base(plantController)
    {
        _plantController = plantController;
    }

    public override void Dispose()
    {
        
    }

    public override void Initialize()
    {
        _plantController.PlantModel.harvestable = false;
    }
}
