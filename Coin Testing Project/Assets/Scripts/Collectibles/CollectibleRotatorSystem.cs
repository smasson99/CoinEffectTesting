using Unity.Entities;
using UnityEngine;

namespace Collectibles
{
    /// <summary>
    /// CollectibleRotatorSystem is an ECS System that rotates it's entities in a random direction. The direction is
    /// choose at the first frame an entity appears in the GetEntities collection.
    /// </summary>
    public class CollectibleRotatorSystem : ComponentSystem
    {
        private struct CollectibleRotatorFilter
        {
            public CollectibleRotator CollectibleRotator;
            public Transform Transform;
        }

        private Vector3 GenerateDirection()
        {
            Quaternion quaternion = Random.rotation;
            return new Vector3(quaternion.x, quaternion.y, quaternion.z);
        }

        protected override void OnUpdate()
        {
            foreach (CollectibleRotatorFilter entity in GetEntities<CollectibleRotatorFilter>())
            {
                if (entity.CollectibleRotator.IsStarting)
                {
                    entity.CollectibleRotator.Direction = GenerateDirection();
                    entity.CollectibleRotator.NotifyStarted();
                }
                
                entity.Transform.Rotate(entity.CollectibleRotator.Direction * entity.CollectibleRotator.Speed *
                                        Time.deltaTime);
            }
        }
    }
}