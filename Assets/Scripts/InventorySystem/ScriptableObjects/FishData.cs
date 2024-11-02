using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewFish", menuName = "Items/Fish")]
    public class FishData : BaseItemData
    {
        [SerializeField] private float weight;
        [SerializeField] private float length;
        [SerializeField] private float averagePrice;
        [SerializeField] private float averageLength;
        [SerializeField] private GameObject prefab;

        [Header("Luck Ranges")] [SerializeField]
        private List<LuckRange> luckRanges = new();


        public float Weight => weight;
        public float Length => length;
        public float AveragePrice => averagePrice;
        public float AverageLength => averageLength;
        public float Scale => length / averageLength;

        public GameObject Prefab
        {
            get
            {
                if (prefab) prefab.transform.localScale = Vector3.one * Scale;
                return prefab;
            }
        }

        private void OnValidate()
        {
            for (var i = 0; i < luckRanges.Count; i++)
            for (var j = i + 1; j < luckRanges.Count; j++)
                if (RangesOverlap(luckRanges[i], luckRanges[j]))
                    Debug.LogWarning(
                        $"Luck ranges at index {i} and {j} are overlapping in FishItem '{name}'. Please adjust the ranges.");
        }

        public void GetRandomAttributesBasedOnLuck(float luck)
        {
            var _luck = Random.Range(0f, 100f);

            foreach (var range in luckRanges)
                if (_luck >= range.chanceRangeStart && _luck < range.chanceRangeEnd)
                {
                    weight = Random.Range(range.minWeight, range.maxWeight);
                    length = Random.Range(range.minLength, range.maxLength);
                    return;
                }

            Debug.LogWarning("No luck range matched the generated luck value. Check luck range settings.");
        }

        private bool RangesOverlap(LuckRange range1, LuckRange range2)
        {
            return range1.chanceRangeStart < range2.chanceRangeEnd && range1.chanceRangeEnd > range2.chanceRangeStart;
        }
    }
}