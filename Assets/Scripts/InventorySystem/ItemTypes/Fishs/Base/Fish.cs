using InventorySystem.ItemTypes.Base;
using InventorySystem.ScriptableObjects;
using UnityEngine;

namespace InventorySystem.ItemTypes.Fishs.Base
{
    public abstract class Fish : BaseItem, IFish
    {
        [SerializeField] protected FishData fishData;
        [SerializeField] protected Rigidbody rigidBody;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody>();
            gameObject.transform.localScale = new Vector3(fishData.Scale, fishData.Scale, fishData.Scale);
        }

        public FishData FishData => fishData;
    }

    public interface IFish : IBaseItem
    {
        FishData FishData { get; }
    }
}