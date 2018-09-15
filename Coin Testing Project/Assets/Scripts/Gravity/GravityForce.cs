using UnityEngine;

namespace Gravity
{
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