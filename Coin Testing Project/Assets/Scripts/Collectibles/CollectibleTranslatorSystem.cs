using Unity.Entities;
using UnityEngine;

namespace Collectibles
{
    public class CollectibleTranslatorSystem : ComponentSystem
    {
        private struct CollectibleTranslatorEntitiesFilter
        {
            public CollectibleTranslator CollectibleTranslator;
            public Transform Transform;
        }

        private static Vector3 minInterval = new Vector3(3.5f, 1.85f, 3.5f);
        private static Vector3 maxInterval = new Vector3(-2.5f, 0.2f, -2.5f);

        private Vector3 GenerateTarget(Vector3 currentPosition)
        {
            return new Vector3(Random.Range(minInterval.x, maxInterval.x) + currentPosition.x,
                Random.Range(minInterval.y, maxInterval.y) + currentPosition.y,
                Random.Range(minInterval.z, maxInterval.z) + currentPosition.z);
        }

        protected override void OnUpdate()
        {
            foreach (CollectibleTranslatorEntitiesFilter entity in GetEntities<CollectibleTranslatorEntitiesFilter>())
            {
                if (entity.CollectibleTranslator.IsSpawning)
                {
                    entity.CollectibleTranslator.SetInitialTarget(GenerateTarget(entity.Transform.position));
                    entity.CollectibleTranslator.NotifySpawned();
                }
                else if (!entity.CollectibleTranslator.WaitingPassed())
                {
                    Vector3 targetPosition = entity.CollectibleTranslator.InitialTarget;
                    Vector3 translationVector3 = targetPosition - entity.Transform.position;

                    entity.Transform.Translate(translationVector3 * entity.CollectibleTranslator.Speed * Time.deltaTime,
                        Space.World);
                }
                else
                {
                    Vector3 targetPosition = entity.CollectibleTranslator.Target.transform.position;
                    targetPosition.y = 0.2f;
                    Vector3 translationVector3 = targetPosition - entity.Transform.position;

                    entity.Transform.Translate(translationVector3 * entity.CollectibleTranslator.Speed * Time.deltaTime,
                        Space.World);
                }
            }
        }
    }
}