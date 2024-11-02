using System.Collections.Generic;
using ItemSystem.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace Editors
{
    [CustomEditor(typeof(FishItem))]
    public class FishItemEditor : Editor
    {
        private SerializedProperty luckRanges;
        private List<Color> rangeColors = new List<Color>();
        private float gapBetweenRanges = 0.001f;

        private void OnEnable()
        {
            luckRanges = serializedObject.FindProperty("luckRanges");
            InitializeColors();
        }

        private void InitializeColors()
        {
            // Ensure we have a color for each luck range, assigning random colors if they don’t exist
            while (rangeColors.Count < luckRanges.arraySize)
            {
                rangeColors.Add(new Color(Random.value, Random.value, Random.value)); // Random initial color
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            // Draw properties of the base class (BaseItem)
            DrawBaseItemProperties();

            // Draw other fields except luckRanges
            EditorGUILayout.PropertyField(serializedObject.FindProperty("weight"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("length"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("averagePrice"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("averageLength"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("prefab"));

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Luck Ranges", EditorStyles.boldLabel);

            Rect barRect = EditorGUILayout.GetControlRect(false, 20);
            EditorGUI.DrawRect(barRect, Color.gray);

            InitializeColors(); // Ensure colors are initialized or updated

            for (int i = 0; i < luckRanges.arraySize; i++)
            {
                var range = luckRanges.GetArrayElementAtIndex(i);
                float start = range.FindPropertyRelative("chanceRangeStart").floatValue;
                float end = range.FindPropertyRelative("chanceRangeEnd").floatValue;

                float startPercentage = Mathf.Clamp01(start / 100f);
                float endPercentage = Mathf.Clamp01(end / 100f);
                float widthPercentage = endPercentage - startPercentage;

                Rect segmentRect = new Rect(
                    barRect.x + barRect.width * startPercentage,
                    barRect.y,
                    barRect.width * widthPercentage,
                    barRect.height
                );

                EditorGUI.DrawRect(segmentRect, rangeColors[i]);
            }

            for (int i = 0; i < luckRanges.arraySize; i++)
            {
                EditorGUILayout.BeginVertical("box");

                var range = luckRanges.GetArrayElementAtIndex(i);
                EditorGUILayout.LabelField($"Range {i + 1}", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(range.FindPropertyRelative("chanceRangeStart"), new GUIContent("Chance Range Start"));
                EditorGUILayout.PropertyField(range.FindPropertyRelative("chanceRangeEnd"), new GUIContent("Chance Range End"));
                EditorGUILayout.PropertyField(range.FindPropertyRelative("minWeight"), new GUIContent("Min Weight"));
                EditorGUILayout.PropertyField(range.FindPropertyRelative("maxWeight"), new GUIContent("Max Weight"));
                EditorGUILayout.PropertyField(range.FindPropertyRelative("minLength"), new GUIContent("Min Length"));
                EditorGUILayout.PropertyField(range.FindPropertyRelative("maxLength"), new GUIContent("Max Length"));
                EditorGUILayout.PropertyField(range.FindPropertyRelative("rarity"), new GUIContent("Rarity")); // Add this line

                // Color picker for each range, initialized with random color
                rangeColors[i] = EditorGUILayout.ColorField("Range Color", rangeColors[i]);

                EditorGUILayout.EndVertical();
                EditorGUILayout.Space();
            }

            if (GUILayout.Button("Add New Luck Range"))
            {
                // Add a new LuckRange element
                luckRanges.InsertArrayElementAtIndex(luckRanges.arraySize);

                // Get reference to the FishItem scriptable object
                FishItem fishItem = (FishItem)target;

                // Set default values for the new item based on FishItem properties
                if (luckRanges.arraySize > 1)
                {
                    // Get the last LuckRange before the new addition
                    var previousRange = luckRanges.GetArrayElementAtIndex(luckRanges.arraySize - 2);
                    var newRange = luckRanges.GetArrayElementAtIndex(luckRanges.arraySize - 1);

                    // Set the new range's start to be the previous range's end + 0.001
                    float previousEnd = previousRange.FindPropertyRelative("chanceRangeEnd").floatValue;
                    newRange.FindPropertyRelative("chanceRangeStart").floatValue = previousEnd + gapBetweenRanges;

                    // Set default values based on FishItem properties
                    newRange.FindPropertyRelative("chanceRangeEnd").floatValue = (previousEnd + 10f) > 100f ? 100f : previousEnd + 10f;
                    newRange.FindPropertyRelative("minWeight").floatValue = fishItem.Weight;
                    newRange.FindPropertyRelative("maxWeight").floatValue = fishItem.Weight;
                    newRange.FindPropertyRelative("minLength").floatValue = fishItem.Length;
                    newRange.FindPropertyRelative("maxLength").floatValue = fishItem.Length;
                    newRange.FindPropertyRelative("rarity").enumValueIndex = (int)fishItem.Rarity; // Add this line
                }
                else
                {
                    var newRange = luckRanges.GetArrayElementAtIndex(luckRanges.arraySize - 1);
                    newRange.FindPropertyRelative("chanceRangeStart").floatValue = 0f;
                    newRange.FindPropertyRelative("chanceRangeEnd").floatValue = 100f;
                    newRange.FindPropertyRelative("minWeight").floatValue = fishItem.Weight ;
                    newRange.FindPropertyRelative("maxWeight").floatValue = fishItem.Weight ;
                    newRange.FindPropertyRelative("minLength").floatValue = fishItem.Length ;
                    newRange.FindPropertyRelative("maxLength").floatValue = fishItem.Length ;
                    newRange.FindPropertyRelative("rarity").enumValueIndex = (int)fishItem.Rarity; // Add this line
                }

                // Assign a random color for the new range
                rangeColors.Add(new Color(Random.value, Random.value, Random.value));
            }

            if (luckRanges.arraySize > 0 && GUILayout.Button("Remove Last Luck Range"))
            {
                luckRanges.DeleteArrayElementAtIndex(luckRanges.arraySize - 1);
                rangeColors.RemoveAt(rangeColors.Count - 1); // Remove the associated color
            }

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawBaseItemProperties()
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("itemName"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("icon"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("description"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("itemType"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("rarity"));
        }
    }
}