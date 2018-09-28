using System;
using UnityEngine;

namespace Spawners.CoinSpawners
{
    /// <summary>
    /// CollectibleSpawnerHandler is a component that must be placed into a single GameObject. There should be only one
    /// instance of this component in one scene. After the Awake call, the static property of CollectibleSpawnerHandler
    /// can be accessed to place a spawner of collectibles to a specific GameObject position.
    ///
    /// See CollectiblesSpawnersController for more details.
    /// </summary>
    public class CollectibleSpawnerHandler : MonoBehaviour
    {
        private static CollectiblesSpawnersController controller;
        public static CollectiblesSpawnersController Controller => controller;

        private void Awake()
        {
            InitializeComponents();
            VerifyComponents();
        }

        private void InitializeComponents()
        {
            controller = GameObject.FindWithTag(Tags.Tags.CollectibleSpawnerTag)?
                .GetComponent<CollectiblesSpawnersController>();
        }

        private void VerifyComponents()
        {
            if (controller == null)
            {
                throw new NullReferenceException(typeof(CollectiblesSpawnersController).Name + " not found!");
            }
        }
    }
}