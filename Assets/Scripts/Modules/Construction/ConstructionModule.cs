using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class ConstructionModule : Module<ConstructionModuleEntity>, Core.IObserver<BoxController>
{
    private List<BoxController> _boxControllers;
    private List<PlantController> _plantControllers;

    public ConstructionModule(ConstructionModuleEntity view) : base(view)
    {
        _boxControllers = new List<BoxController>();
        _plantControllers = new List<PlantController>();
    }

    public override void Dispose()
    {
        
    }

    public override void Initialize()
    {
        for (int i = 0; i < _view.boxEntities.Length; i++)
        {
            var boxEntity = _view.boxEntities[i];
            var boxConfig = _view.boxConfigs[i];
            var boxController = 
                new BoxController(boxEntity, boxConfig, _view.GetPlantConfig(boxConfig.plantId));
            boxEntity.Init(_view, boxController);
            
            boxController.AddObserver(this);
            _boxControllers.Add(boxController);
        }
    }

    public void OnObjectChanged(BoxController observable)
    {
        if (observable.BoxModel.plantable)
        {
            observable.BoxEntity.gameObject.SetActive(false);

            var plantEntity = _view.GetPlantEntity(
                observable.BoxModel.plantId,
                observable.BoxEntity.transform.position + new Vector3(0, 0.5f, 0)
            );
            var plantConfig = _view.GetPlantConfig(
                observable.BoxModel.plantId
            );

            var plantController = new PlantController(plantEntity, plantConfig);
            _plantControllers.Add(plantController);
        }
    }
}
