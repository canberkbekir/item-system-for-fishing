using System;
using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    [Serializable]
    public class LuckRange
    {
        [Range(0, 100)] public float chanceRangeStart;

        [Range(0, 100)] public float chanceRangeEnd;

        public RarityType rarity;
        public float minWeight;
        public float maxWeight;

        public float minLength;
        public float maxLength;
    }
}