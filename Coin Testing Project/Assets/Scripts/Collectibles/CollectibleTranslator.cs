using Player_Gold;
using TMPro;
using UnityEngine;

namespace Collectibles
{
    public class CollectibleTranslator : MonoBehaviour
    {
        [Tooltip("The speed to translate the collectible")] [SerializeField]
        private float speed = 1.5f;

        private PlayerGoldContainer playerGoldContainer;

        public float Speed
        {
            get => speed;
            private set => speed = value;
        }
        
        private GameObject target = null;
        private Vector3 initialTarget = Vector3.zero;
        
        public GameObject Target
        {
            get => target;
            private set => target = value;
        }

        public Vector3 InitialTarget
        {
            get => initialTarget;
            private set => initialTarget = value;
        }

        private bool isSpawning = true;

        public bool IsSpawning
        {
            get => isSpawning;
            private set => isSpawning = value;
        }
        
        private static float waitingTimeInSeconds = 5f;

        private float lastTime;

        private void Awake()
        {
            lastTime = Time.time;
        }

        public PlayerGoldContainer PlayerGoldContainer => playerGoldContainer;

        public bool WaitingPassed()
        {
            return lastTime + waitingTimeInSeconds < Time.time;
        }

        public void SetInitialTarget(Vector3 target)
        {
            initialTarget = target;
        }

        public void SetTarget(GameObject target, PlayerGoldContainer playerGoldContainerComponent)
        {
            this.target = target;
            playerGoldContainer = playerGoldContainerComponent;
        }
        
        public void NotifySpawned()
        {
            isSpawning = false;
        }
    }
}