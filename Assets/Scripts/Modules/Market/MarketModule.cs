using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketModule : Module<MarketModuleEntity>, Core.IObserver<CustomerController>
{
    public int totalCustomers = 2;
    private List<CustomerController> _customerControllers;

    public MarketModule(MarketModuleEntity view) : base(view)
    {
        
    }

    public override void Dispose()
    {
        
    }

    public override void Initialize()
    {
        _customerControllers = new List<CustomerController>();
        for (int i = 0; i < totalCustomers; i++)
        {
            SpawnCustomer();
        }
    }

    public void OnObjectChanged(CustomerController observable)
    {
        if (observable.CustomerModel.isWaiting)
        {
            
        }
    }

    private void SpawnCustomer()
    {
        var dock = _view.GetRandomDock();
        var customerEntity = _view.GetCharacterEntity();
        var customerController = new CustomerController(customerEntity, dock.customerPos);
        _customerControllers.Add(customerController);
    }

}
