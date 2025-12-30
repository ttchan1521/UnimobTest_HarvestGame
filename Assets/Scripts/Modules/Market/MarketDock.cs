using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketDock : MonoBehaviour
{
    public Transform currencyPoint;
    public Transform deliveryPoint;

    public CustomerController customer;
    public DeliveryController delivery;

    public Vector3 customerPos
    {
        get
        {
            float deltaZ = deliveryPoint.position.z - currencyPoint.position.z;
            float customerZ = currencyPoint.position.z - deltaZ;
            
            return new Vector3(
                deliveryPoint.position.x,
                deliveryPoint.position.y,
                customerZ
            );
        }
    }
    
}
