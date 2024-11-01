using System.Collections.Generic;
using UnityEngine;

namespace ItemSystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewFish", menuName = "Items/Fish")]
    public class FishItem : BaseItem, IFish
    {
        [SerializeField] private float weight;
        [SerializeField] private float length;
        [SerializeField] private int rarity;
        [SerializeField] private float averagePrice;
        [SerializeField] private float averageLength;

        [Header("Luck Ranges")]
        [SerializeField] private List<LuckRange> luckRanges = new List<LuckRange>();

        public float Weight => weight;
        public float Length => length;
        public int Rarity => rarity;
        public float AveragePrice => averagePrice;
        public float AverageLength => averageLength;
        public float Scale => length / averageLength; 
        public void GetRandomAttributesBasedOnLuck(float luck)
        { 
            var _luck = Random.Range(0f, 100f);

            foreach (var range in luckRanges)
            {
                if (_luck >= range.chanceRangeStart && _luck < range.chanceRangeEnd)
                {
                    weight = Random.Range(range.minWeight, range.maxWeight);
                    length = Random.Range(range.minLength, range.maxLength);
                    return;
                }
            }

            Debug.LogWarning("No luck range matched the generated luck value. Check luck range settings.");
        }
 
        private void OnValidate()
        {
            for (int i = 0; i < luckRanges.Count; i++)
            {
                for (int j = i + 1; j < luckRanges.Count; j++)
                {
                    if (RangesOverlap(luckRanges[i], luckRanges[j]))
                    {
                        Debug.LogWarning($"Luck ranges at index {i} and {j} are overlapping in FishItem '{name}'. Please adjust the ranges.");
                    }
                }
            }
        }
 
        private bool RangesOverlap(LuckRange range1, LuckRange range2)
        {
            return range1.chanceRangeStart < range2.chanceRangeEnd && range1.chanceRangeEnd > range2.chanceRangeStart;
        }
    }
}
