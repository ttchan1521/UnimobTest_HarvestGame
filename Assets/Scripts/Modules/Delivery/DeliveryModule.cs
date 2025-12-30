using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryModule : Module<DeliveryModuleEntity>, Core.IObserver<PlantController>, Core.IObserver<CustomerController>
{
    private List<DeliveryController> _deliveryControllers;

    public DeliveryModule(DeliveryModuleEntity view) : base(view)
    {
    }

    public override void Dispose()
    {
        
    }

    public override void Initialize()
    {
        
    }

    public void OnObjectChanged(PlantController observable)
    {
        if (observable.PlantModel.harvestable)
        {
            var characterEntity = _view.GetCharacterEntity();
            var deliveryController = new DeliveryController(characterEntity, observable);
            _deliveryControllers.Add(deliveryController);
        }
    }

    public void OnObjectChanged(CustomerController observable)
    {
        if (observable.CustomerModel.isWaiting)
        {
            for (int i = 0; i < _deliveryControllers.Count; i++)
            {
                if (_deliveryControllers[i].DeliveryModel.isHarvested)
                {
                    
                }
            }
        }
    }
}
