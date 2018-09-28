using Player_Gold;
using TMPro;
using UnityEngine;

namespace Collectibles
{
    /// <summary>
    /// CollectibleTranslator is an ECS Component that contains the data required to 
    /// </summary>
    public class CollectibleTranslator : MonoBehaviour
    {
        private const float WaitingTimeInSeconds = 5f;
        
        [Tooltip("The speed to translate the collectible")] [SerializeField]
        private float speed = 1.5f;

        private float lastTime;

        private void Awake()
        {
            lastTime = Time.time;
        }

        public float Speed
        {
            get => speed;
            private set => speed = value;
        }

        public GameObject Target { get; private set; }

        public Vector3 InitialTarget { get; private set; }

        public bool IsSpawning { get; private set; } = true;

        public PlayerGoldContainer PlayerGoldContainer { get; private set; }

        public bool WaitingPassed => lastTime + WaitingTimeInSeconds < Time.time;
        
        /// <summary>
        /// Function that sets the initial point in 3D world to translate to when starting.
        /// </summary>
        /// <param name="newInitialTarget">Vector3 that represent the 3D world position to translate to when
        /// starting.</param>
        public void SetInitialTarget(Vector3 newInitialTarget)
        {
            InitialTarget = newInitialTarget;
        }

        /// <summary>
        /// Function that sets the collectibles translation target that will define the direction of the translation.
        /// </summary>
        /// <param name="receiverGameObject">GameObject that represents the translation target, wich defines the
        /// translation direction.</param>
        /// <param name="playerGoldContainerComponent">PlayerGoldContainter (todo when merging : remplace this
        /// parameter) that contains the amouth of gold for each player.</param>
        public void SetTarget(GameObject receiverGameObject, PlayerGoldContainer playerGoldContainerComponent)
        {
            Target = receiverGameObject;
            PlayerGoldContainer = playerGoldContainerComponent;
        }

        public void NotifySpawned()
        {
            IsSpawning = false;
        }
    }
}