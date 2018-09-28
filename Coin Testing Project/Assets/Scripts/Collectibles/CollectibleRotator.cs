using UnityEngine;

namespace Collectibles
{
    /// <summary>
    /// ECS Component that contains the data required for the ECS Systems to rotate the collectibles.
    /// </summary>
    public class CollectibleRotator : MonoBehaviour
    {
        [Tooltip("The rotation speed of this collectible.")] [SerializeField]
        private float speed = 1.2f;

        private Vector3 direction;
        private bool isStarting = true;

        public bool IsStarting => isStarting;
        public float Speed => speed;

        public Vector3 Direction
        {
            get => direction;
            set => direction = value;
        }

        public void NotifyStarted()
        {
            isStarting = false;
        }
    }
}