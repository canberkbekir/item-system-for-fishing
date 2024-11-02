using System.Collections.Generic;
using InventorySystem.ItemTypes.Base;
using UnityEngine;

namespace InventorySystem
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private Inventory inventory;
        
        public Inventory Inventory => inventory;
        
        private void Awake()
        {
            inventory = gameObject.AddComponent<Inventory>();
        }
        
        public void AddItem(BaseItem item)
        {
            inventory.AddItem(item);
        }
        
        public void RemoveItem(BaseItem item)
        {
            inventory.RemoveItem(item);
        }
        
        public void RemoveItem()
        {
            inventory.RemoveItem();
        }
        
        public void ChangeCurrentIndex(int index)
        {
            inventory.ChangeCurrentIndex(index);
        }
        
    }
}