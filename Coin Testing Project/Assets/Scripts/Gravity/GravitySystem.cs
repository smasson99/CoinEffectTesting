using Unity.Entities;
using UnityEngine;

namespace Gravity
{
    /// <summary>
    /// ECS System that simulates the gravity uder it's entities.
    ///
    /// Note: The entities must posses a GravityForce component and a CharacterController component.
    /// See GravityForce for more details.
    /// </summary>
    public class GravitySystem : ComponentSystem
    {
        private struct GravityEntitiesFilter
        {
            public GravityForce GravityForce;
            public CharacterController CharacterController;
        }


        protected override void OnUpdate()
        {
            foreach (GravityEntitiesFilter entity in GetEntities<GravityEntitiesFilter>())
            {
                entity.CharacterController.SimpleMove(new Vector3(0, -entity.GravityForce.GravityForceFactor, 0));
            }
        }
    }
}