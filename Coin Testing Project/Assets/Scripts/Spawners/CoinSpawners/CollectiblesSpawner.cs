using UnityEngine;

namespace Spawners.CoinSpawners
{
    /// <summary>
    /// CollectiblesSpawner is a ECS component that contains the data required in order for the ECS Systems to spawn
    /// collectibles on it.
    /// </summary>
    public class CollectiblesSpawner : MonoBehaviour
    {
        [Tooltip("The prefab to spawn.")] [SerializeField]
        private GameObject collectiblePrefab;

        private void Spawn(GameObject collectiblesDestinator)
        {
            IsSpawning = true;
            CoinTarget = collectiblesDestinator;
        }

        public GameObject CoinTarget { get; private set; }

        public int NumberOfCollectibles { get; private set; } = 10;

        public bool IsSpawning { get; private set; }
        
        public GameObject CollectiblePrefab => collectiblePrefab;

        /// <summary>
        /// Function wich initializes the data required for the ECS Systems to spawn the collectibles.
        /// After the call of this function, the Systems will see this spawner as a "Spawner to spawn".
        /// </summary>
        /// <param name="collectiblesDestinator">GameObject that represents the player or the entity that will recieve
        /// the collectibles after their spawn.</param>
        /// <param name="numberOfCollectibles">Integer that represent the number of collectibles to spawn to this
        /// spawner.</param>
        public void Spawn(GameObject collectiblesDestinator, int numberOfCollectibles)
        {
            NumberOfCollectibles = numberOfCollectibles;
            Spawn(collectiblesDestinator);
        }

        public void NotifySpawned()
        {
            IsSpawning = false;
        }
    }
}