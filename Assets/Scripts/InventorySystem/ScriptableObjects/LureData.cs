using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewLure", menuName = "Items/Lure")]
    public class LureData : BaseItemData
    {
        [SerializeField] private float attractionRate;
        [SerializeField] private float sinkSpeed;
        [SerializeField] private bool isFloating;

        public float AttractionRate => attractionRate;
        public float SinkSpeed => sinkSpeed;
        public bool IsFloating => isFloating;
    }
}