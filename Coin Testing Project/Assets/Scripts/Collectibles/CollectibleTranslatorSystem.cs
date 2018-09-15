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

        protected override void OnUpdate()
        {
            foreach (CollectibleTranslatorEntitiesFilter entity in GetEntities<CollectibleTranslatorEntitiesFilter>())
            {
                Vector3 targetPosition = entity.CollectibleTranslator.Target.transform.position;
                targetPosition.y = 0.2f;
                Vector3 translationVector3 = targetPosition - entity.Transform.position;

                if (!entity.CollectibleTranslator.WaitsBeforeTranslate || entity.CollectibleTranslator.WaitingPassed())
                {
                    entity.Transform.Translate(translationVector3 * entity.CollectibleTranslator.Speed * Time.deltaTime,
                        Space.World);
                }
            }
        }
    }
}