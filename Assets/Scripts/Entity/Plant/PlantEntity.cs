using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEntity : MonoBehaviour
{
    [SerializeField] private Transform[] _growthPoints;
    [SerializeField] private FruitEntity _fruitEntityPrefab;
    public Transform deliveryPoint;
    public List<FruitEntity> fruitEntities;

    public List<FruitEntity> SpawnFruit(int count)
    {
        fruitEntities = new List<FruitEntity>();
        for (int i = 0; i < Mathf.Min(count, _growthPoints.Length); i++)
        {
            var fruitObj = ObjectPoolManager.Spawn(_fruitEntityPrefab.gameObject);
            fruitObj.transform.position = _growthPoints[i].position;
            var fruitEntity = fruitObj.GetComponent<FruitEntity>();
            fruitEntities.Add(fruitEntity);
        }

        return fruitEntities;
    }

}
