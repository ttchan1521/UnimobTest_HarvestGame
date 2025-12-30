
using System;
using UnityEngine;

namespace Game.Config
{
    [CreateAssetMenu(fileName = "PlantConfig", menuName = "Data/PlantConfig")]
    public class PlantConfig : ScriptableObject
    {
        public int id;
        public string plantName;
        public Sprite icon;
        public PlantLevel[] levels;
    }

    [Serializable]
    public struct PlantLevel
    {
        public int income;
        public float harvestTime;
        public int upgradeCost;
    }
}
