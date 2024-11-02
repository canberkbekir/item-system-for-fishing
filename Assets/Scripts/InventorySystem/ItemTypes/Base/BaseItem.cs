using UnityEngine;

namespace InventorySystem.ItemTypes.Base
{
    public abstract class BaseItem : MonoBehaviour, IBaseItem
    {
        public virtual void Use()
        {
            Debug.Log("Using item");
        }
    }

    public interface IBaseItem
    {
        void Use();
    }
}