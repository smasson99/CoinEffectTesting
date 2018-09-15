using UnityEngine;

namespace Inputs
{
    public class KeyDestroyer : MonoBehaviour
    {
        [Tooltip("The key to prew to destroy this object.")] [SerializeField]
        private string keyToPressToDestroy = "space";
    
        public string KeyToPressToDestroy
        {
            get => keyToPressToDestroy;
            private set => keyToPressToDestroy = value;
        }
    }
}