using System;
using UnityEngine;

namespace Spawners.CoinSpawners
{
    public class CollectibleSpawnerHandler : MonoBehaviour
    {
        private static CollectiblesSpawnersController controller;

        private void Awake()
        {
            InitiateComponents();
            VerifyComponents();
        }

        private void InitiateComponents()
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

        public static CollectiblesSpawnersController Controller
        {
            get => controller;
            private set => controller = value;
        }
    }
}