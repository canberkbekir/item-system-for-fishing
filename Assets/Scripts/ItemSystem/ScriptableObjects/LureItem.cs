using UnityEngine;

namespace ItemSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewLure", menuName = "Items/Lure")]
    public class LureItem : BaseItem, ILure
    {
        [SerializeField] private float attractionRate;
        [SerializeField] private float sinkSpeed;
        [SerializeField] private bool isFloating;

        public float AttractionRate => attractionRate;
        public float SinkSpeed => sinkSpeed;
        public bool IsFloating => isFloating;
    }
}
