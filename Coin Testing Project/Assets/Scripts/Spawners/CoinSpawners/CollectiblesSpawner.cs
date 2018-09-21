using UnityEngine;

namespace Spawners
{
    public class CollectiblesSpawner : MonoBehaviour
    {
        [Tooltip("The number of collectibles to spawn.")] [SerializeField]
        private int numberOfCollectiblesToSpawn = 10;

        [Tooltip("The prefab to spawn.")] [SerializeField]
        private GameObject collectiblePrefab = null;

        private bool isSpawning = false;
        private GameObject coinTarget;

        public GameObject CoinTarget
        {
            get => coinTarget;
            private set => coinTarget = value;
        }

        public int NumberOfCollectiblesToSpawn
        {
            get => numberOfCollectiblesToSpawn;
            set => numberOfCollectiblesToSpawn = value;
        }

        public GameObject CollectiblePrefab
        {
            get => collectiblePrefab;
            private set => collectiblePrefab = value;
        }

        public bool IsSpawning
        {
            get => isSpawning;
            private set => isSpawning = value;
        }

        public void Spawn(GameObject target, int numberOfInstatiates)
        {
            numberOfCollectiblesToSpawn = numberOfInstatiates;
            Spawn(target);
        }

        public void Spawn(GameObject target)
        {
            isSpawning = true;
            coinTarget = target;
        }

        public void NotifySpawned()
        {
            isSpawning = false;
        }
    }
}