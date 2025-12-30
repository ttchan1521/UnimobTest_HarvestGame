using System.Collections;
using System.Collections.Generic;
using Game.Config;
using UnityEngine;

public class ConstructionModuleEntity : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private ConstructionUnlockView _unlockViewPrefab;
    [SerializeField] private BuildingView _buildingViewPrefab;

    [SerializeField] private PlantEntity _plantEntityPrefab;

    public BoxConfig[] boxConfigs;
    public PlantConfig[] plantConfigs;
    public BoxEntity[] boxEntities;

    public ConstructionUnlockView GetConstructionUnlockView()
    {
        var viewObj = ObjectPoolManager.Spawn(_unlockViewPrefab.gameObject);
        viewObj.transform.SetParent(_canvas.transform);
        return viewObj.GetComponent<ConstructionUnlockView>();
    }

    public BuildingView GetBuildingView(GameObject parent, Vector3 offset)
    {
        var viewObj = ObjectPoolManager.Spawn(_buildingViewPrefab.gameObject);
        var buildingView = viewObj.GetComponent<BuildingView>();
        buildingView.SetParentAndPosition(parent.transform, offset);
        return buildingView;
    }

    public PlantEntity GetPlantEntity(int plantId, Vector3 position)
    {
        var plantEntity = ObjectPoolManager.Spawn(_plantEntityPrefab.gameObject);
        plantEntity.transform.position = position;
        return plantEntity.GetComponent<PlantEntity>();
    }

    public PlantConfig GetPlantConfig(int plantId)
    {
        for (int i = 0; i < plantConfigs.Length; i++)
        {
            if (plantConfigs[i].id == plantId)
            {
                return plantConfigs[i];
            }
        }

        return null;
    }
}
