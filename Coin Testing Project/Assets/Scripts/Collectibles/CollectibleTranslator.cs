using TMPro;
using UnityEngine;

namespace Collectibles
{
    public class CollectibleTranslator : MonoBehaviour
    {
        [Tooltip("The speed to translate the collectible")] [SerializeField]
        private float speed = 1.5f;

        public float Speed
        {
            get => speed;
            private set => speed = value;
        }
        
        [SerializeField]
        private GameObject target = null;
        
        public GameObject Target
        {
            get => target;
            set => target = value;
        }

        [Tooltip("Does the translator waits before translate to target?")]
        [SerializeField] private bool waitsBeforeTranslate = true;

        public bool WaitsBeforeTranslate
        {
            get => waitsBeforeTranslate;
            set => waitsBeforeTranslate = value;
        }

        private bool isSpawning = true;

        public bool IsSpawning
        {
            get => isSpawning;
            private set => isSpawning = value;
        }

        [Tooltip("Time to wait in seconds before translating.")]
        [SerializeField]
        private float waitingTimeInSeconds = 1.2f;

        private float lastTime;

        private void Awake()
        {
            lastTime = Time.time;
        }

        public bool WaitingPassed()
        {
            return lastTime + waitingTimeInSeconds < Time.time;
        }
        
        
    }
}