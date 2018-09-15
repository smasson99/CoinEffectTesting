using Unity.Entities;
using UnityEngine;

namespace Inputs
{
    public class InputSystem : ComponentSystem
    {
        private struct KeyDestroyersEntityFilter
        {
            public KeyDestroyer KeyDestroyer;
        }

        protected override void OnUpdate()
        {
            foreach (KeyDestroyersEntityFilter entity in GetEntities<KeyDestroyersEntityFilter>())
            {
                if (Input.GetKeyDown(entity.KeyDestroyer.KeyToPressToDestroy))
                {
                    Object.Destroy(entity.KeyDestroyer.gameObject);
                }
            }
        }
    }
}