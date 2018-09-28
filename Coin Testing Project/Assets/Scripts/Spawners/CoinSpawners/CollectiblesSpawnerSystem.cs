using System.Threading;
using Boo.Lang;
using Collectibles;
using Player_Gold;
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

            //GetEntities list is dealocated when an Instantiate is done inside, the two foreach are REQUIRED
            foreach (CollectiblesSpawnersFilter entity in collectiblesSpawnersToSpawn)
            {
                PlayerGoldContainer goldContainer =
                    entity.CollectiblesSpawner.CoinTarget.GetComponent<PlayerGoldContainer>();
                for (int i = 0; i < entity.CollectiblesSpawner.NumberOfCollectibles; ++i)
                {
                    GameObject instantiate = GameObject.Instantiate(entity.CollectiblesSpawner.CollectiblePrefab);
                    instantiate.transform.position = entity.Transform.position;
                    instantiate.GetComponent<CollectibleTranslator>()
                        ?.SetTarget(entity.CollectiblesSpawner.CoinTarget, goldContainer);

                    entity.CollectiblesSpawner.NotifySpawned();
                }
            }
        }
    }
}