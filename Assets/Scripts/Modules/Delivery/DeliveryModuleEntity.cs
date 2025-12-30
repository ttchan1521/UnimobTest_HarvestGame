using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryModuleEntity : MonoBehaviour
{
    [SerializeField] public CharacterEntity characterEntityPrefab;
    [SerializeField] public Transform startCharacterPoint;


    public CharacterEntity GetCharacterEntity()
    {
        var characterEntity = ObjectPoolManager.Spawn(characterEntityPrefab.gameObject);
        characterEntity.transform.position = startCharacterPoint.position;
        return characterEntity.GetComponent<CharacterEntity>();
    }
}
