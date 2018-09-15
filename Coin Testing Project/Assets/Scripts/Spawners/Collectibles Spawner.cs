using UnityEngine;

namespace Spawners
{
    public class CollectiblesSpawner : MonoBehaviour
    {
        [Tooltip("The number of collectibles to spawn.")] [SerializeField]
        private int numberOfCollectiblesToSpawn = 10;

        public int NumberOfCollectiblesToSpawn
        {
            get => numberOfCollectiblesToSpawn;
            set => numberOfCollectiblesToSpawn = value;
        }

        [Tooltip("The prefab to spawn.")] [SerializeField]
        private GameObject collectiblePrefab = null;

        public GameObject CollectiblePrefab
        {
            get => collectiblePrefab;
            private set => collectiblePrefab = value;
        }

        private bool isSpawning = false;

        public bool IsSpawning
        {
            get => isSpawning;
            private set => isSpawning = value;
        }

        public void Spawn(int numberOfInstatiates)
        {
            numberOfCollectiblesToSpawn = numberOfInstatiates;
            isSpawning = true;
        }

        public void NotifySpawned()
        {
            isSpawning = false;
        }
    }
}