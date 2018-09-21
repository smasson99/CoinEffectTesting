﻿using System.Threading;
using Boo.Lang;
using Collectibles;
using Unity.Entities;
using UnityEngine;

namespace Spawners.CoinSpawners
{
    public class CollectiblesSpawnerSystem : ComponentSystem
    {
        private struct CollectiblesSpawnersFilter
        {
            public Transform Transform;
            public CollectiblesSpawner CollectiblesSpawner;
        }

        protected override void OnUpdate()
        {
            List<CollectiblesSpawnersFilter> collectiblesSpawnersToSpawn = new List<CollectiblesSpawnersFilter>();
            foreach (CollectiblesSpawnersFilter entity in GetEntities<CollectiblesSpawnersFilter>())
            {
                if (entity.CollectiblesSpawner.IsSpawning)
                {
                    collectiblesSpawnersToSpawn.Add(entity);
                }
            }

            foreach (CollectiblesSpawnersFilter entity in collectiblesSpawnersToSpawn)
            {
                for (int i = 0; i < entity.CollectiblesSpawner.NumberOfCollectiblesToSpawn; ++i)
                {
                    GameObject instantiate = GameObject.Instantiate(entity.CollectiblesSpawner.CollectiblePrefab);
                    instantiate.transform.position = entity.Transform.position;
                    instantiate.GetComponent<CollectibleTranslator>()
                        ?.SetTarget(entity.CollectiblesSpawner.CoinTarget);
                    
                    entity.CollectiblesSpawner.NotifySpawned();
                }
            }
        }
    }
}