using System.Collections.Generic;
using Spawners.CoinSpawners;
using Unity.Entities;
using UnityEngine;

namespace Collectibles
{
    /// <summary>
    /// CollectiblesDestroyerSystem is a ECS System that destroys the collectibles GameObjects when they are
    /// close enough to their destinator. This system also adds gold into the inventory of the target player
    /// equivalent to the collectibles value.
    /// </summary>
    public class CollectiblesDestroyerSystem : ComponentSystem
    {
        private struct Filter
        {
            public Transform Transform;
            public CollectibleTranslator CollectibleTranslator;
            public CollectibleValue CollectibleValue;
        }

        private bool IsNearTarget(Vector3 currentPosition, Vector3 targetPosition, float minDistance)
        {
            Vector3 targetVector3 = targetPosition - currentPosition;
            return minDistance * minDistance >= targetVector3.sqrMagnitude;
        }

        protected override void OnUpdate()
        {
            List<Filter> entitiesToDestroy = new List<Filter>();

            foreach (Filter entity in GetEntities<Filter>())
            {
                if (!entity.CollectibleTranslator.IsSpawning && IsNearTarget(entity.Transform.position,
                        entity.CollectibleTranslator.Target.transform.position,
                        0.1f))
                {
                    entitiesToDestroy.Add(entity);
                }
            }

            foreach (Filter entity in entitiesToDestroy)
            {
                entity.CollectibleTranslator.PlayerGoldContainer.AddGold(entity.CollectibleValue.ValueInGoldPieces);
                Object.Destroy(entity.Transform.gameObject);
            }
        }
    }
}