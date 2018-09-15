using Unity.Entities;
using UnityEngine;

namespace Spawners
{
    public class CollectiblesSpawnerSystem : ComponentSystem
    {
        private struct CollectiblesSpawnersFilter
        {
            public CollectiblesSpawner CollectiblesSpawner;
            public Transform Transform;
        }
        
        protected override void OnUpdate()
        {
            foreach (CollectiblesSpawnersFilter entity in GetEntities<CollectiblesSpawnersFilter>())
            {
                if (entity.CollectiblesSpawner.IsSpawning)
                {
                    for (int i = 0; i < entity.CollectiblesSpawner.NumberOfCollectiblesToSpawn; ++i)
                    {
                        GameObject instantiate = Object.Instantiate(entity.CollectiblesSpawner.CollectiblePrefab);
                        instantiate.transform.position = entity.Transform.position;
                    }
                    entity.CollectiblesSpawner.NotifySpawned();
                }
            }
        }
    }
}