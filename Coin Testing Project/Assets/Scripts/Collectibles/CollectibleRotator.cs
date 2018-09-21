using UnityEngine;

namespace Collectibles
{
    public class CollectibleRotator : MonoBehaviour
    {
        [Tooltip("The rotation speed of this collectible.")] [SerializeField]
        private float speed = 1.2f;

        private Vector3 direction;

        private bool isStarting = true;

        public bool IsStarting
        {
            get => isStarting;
            private set => isStarting = value;
        }

        public Vector3 Direction
        {
            get => direction;
            set => direction = value;
        }
        
        public float Speed
        {
            get => speed;
            private set => speed = value;
        }

        public void NotifyStarted()
        {
            isStarting = false;
        }
    }
}