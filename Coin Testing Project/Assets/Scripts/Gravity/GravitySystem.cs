using Unity.Entities;
using UnityEngine;

namespace Gravity
{
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