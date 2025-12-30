using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketModuleEntity : MonoBehaviour
{
    [SerializeField] private CharacterEntity characterEntity;
    [SerializeField] private MarketDock[] docks;
    [SerializeField] private Transform startCustomerPoint;
    [SerializeField] private Transform endCustomerPoint;
    [SerializeField] private Transform endDeliveryPoint;

    public MarketDock GetRandomDock()
    {
        // Lọc những dock có customer null
        List<MarketDock> availableDocks = new List<MarketDock>();
        
        for (int i = 0; i < docks.Length; i++)
        {
            if (docks[i].customer == null)
            {
                availableDocks.Add(docks[i]);
            }
        }
        
        // Nếu không có dock trống, return null
        if (availableDocks.Count == 0)
            return null;
        
        // Random 1 dock từ list available
        int randomIndex = Random.Range(0, availableDocks.Count);
        return availableDocks[randomIndex];
    }

    public CharacterEntity GetCharacterEntity()
    {
        var newCharacterEntity = ObjectPoolManager.Spawn(characterEntity.gameObject);
        newCharacterEntity.transform.position = startCustomerPoint.position;
        return newCharacterEntity.GetComponent<CharacterEntity>();
    }
}
