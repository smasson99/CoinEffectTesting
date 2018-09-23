using Spawners.CoinSpawners;
using UnityEngine;

namespace Spawners
{
    public class CollectibleSpawnerHandler : MonoBehaviour
    {
        private static CollectiblesSpawnersController controller;

        private void Awake()
        {
            InitiateComponents();

            if (controller == null)
            {
                Debug.Log("CollectiblesSpawnerController not found!");
            }
        }

        private void InitiateComponents()
        {
            controller = GameObject.FindWithTag(Tags.Tags.COLLECTIBLE_SPAWNER)?
                .GetComponent<CollectiblesSpawnersController>();
        }

        public static CollectiblesSpawnersController Controller
        {
            get => controller;
            private set => controller = value;
        }
    }
}