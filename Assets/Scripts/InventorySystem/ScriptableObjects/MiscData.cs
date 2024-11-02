using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    public class MiscData : BaseItemData
    {
        [SerializeField] private GameObject prefab;
        public GameObject Prefab => prefab;
    }
}