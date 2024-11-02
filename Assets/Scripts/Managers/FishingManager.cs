using InventorySystem.ScriptableObjects.Containers;
using UnityEngine;

namespace Managers
{
    public class FishingManager : MonoBehaviour
    {
        [SerializeField] private Transform fishingSpawnPoint;
        [SerializeField] private FishItemLibrary fishItemLibrary;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) SpawnFish();
        }

        public void SpawnFish()
        {
            var fishItem = fishItemLibrary.GetRandomFishItem(0);
            if (fishItem == null || fishItem.Prefab == null)
            {
                Debug.LogError("FishItem or its Prefab is null.");
                return;
            }

            var fish = Instantiate(fishItem.Prefab, fishingSpawnPoint.position, Quaternion.identity);
            fish.GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}