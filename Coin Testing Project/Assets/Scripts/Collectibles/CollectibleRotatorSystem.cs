using Unity.Entities;
using UnityEngine;

namespace Collectibles
{
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

        protected override void OnStartRunning()
        {
            foreach (CollectibleRotatorFilter entity in GetEntities<CollectibleRotatorFilter>())
            {
                entity.CollectibleRotator.Direction = GenerateDirection();
            }
        }

        protected override void OnUpdate()
        {
            foreach (CollectibleRotatorFilter entity in GetEntities<CollectibleRotatorFilter>())
            {
                entity.Transform.Rotate(entity.CollectibleRotator.Direction * entity.CollectibleRotator.Speed *
                                        Time.deltaTime);
            }
        }
    }
}