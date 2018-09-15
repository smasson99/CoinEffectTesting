using UnityEngine;

namespace Collectibles
{
    public class CollectibleRotator : MonoBehaviour
    {
        [Tooltip("The rotation speed of this collectible.")] [SerializeField]
        private float speed = 1.2f;

        public float Speed
        {
            get => speed;
            private set => speed = value;
        }

        [Tooltip("The direction of the rotation of this collectible.")]
        private Vector3 direction;

        public Vector3 Direction
        {
            get => direction;
            set => direction = value;
        }
    }
}