
using UnityEngine;

namespace Game.Config
{
    [CreateAssetMenu(fileName = "BoxConfig", menuName = "Data/BoxConfig")]
    public class BoxConfig : ScriptableObject
    {
        public int cost;
        public float buildingTime;
        public int plantId;
    }
}