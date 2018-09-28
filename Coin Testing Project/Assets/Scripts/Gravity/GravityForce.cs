using UnityEngine;

namespace Gravity
{
    /// <summary>
    /// ECS Component that contains the data required in order to simulate the gravity force on a CharacterController.
    /// </summary>
    public class GravityForce : MonoBehaviour
    {
        [Tooltip("The gravity force to apply to this GameObject")]
        [SerializeField]
        private float gravityForceFactor = 1.0f;

        public float GravityForceFactor
        {
            get => gravityForceFactor;
            private set => gravityForceFactor = value;
        }
    }
}