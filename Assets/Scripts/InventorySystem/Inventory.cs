using System;
using InventorySystem.ItemTypes.Base;
using JetBrains.Annotations;
using UnityEngine;

namespace InventorySystem
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int inventorySize;
        [SerializeField] private BaseItem[] items;
        [SerializeField] private int currentIndex = 0;
        
        public BaseItem[] Items => items;
        public int InventorySize => inventorySize;
        public int CurrentIndex => currentIndex;
        [CanBeNull] public BaseItem CurrentItem => items[currentIndex];
        
        public event Action<BaseItem> OnItemAdded;
        public event Action<BaseItem> OnItemRemoved;
        public event Action OnItemListChanged;
        

        private void Start()
        {
            items = new BaseItem[inventorySize];
        }
        
        public void ChangeCurrentIndex(int index)
        {
            if (index < 0 || index >= items.Length) return;
            currentIndex = index;
            OnItemListChanged?.Invoke();
        }
        
        public bool AddItem(BaseItem item)
        {
            for (var i = 0; i < items.Length; i++)
            {
                if (items[i] != null) continue;
                items[i] = item;
                OnItemAdded?.Invoke(item);
                OnItemListChanged?.Invoke();
                return true; 
            }

            return false;
        }
        
        public bool RemoveItem(BaseItem item)
        {
            for (var i = 0; i < items.Length; i++)
            {
                if (items[i] != item) continue;
                items[i] = null;
                OnItemRemoved?.Invoke(item);
                OnItemListChanged?.Invoke();
                return true;
            }

            return false;
        }
        
        public bool RemoveItem()
        {
            if (currentIndex < 0 || currentIndex >= items.Length) return false;
            items[currentIndex] = null;
            OnItemRemoved?.Invoke(items[currentIndex]);
            OnItemListChanged?.Invoke();
            return true;
        }
    }
}