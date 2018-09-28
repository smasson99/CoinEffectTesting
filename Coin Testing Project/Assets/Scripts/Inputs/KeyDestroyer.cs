using UnityEngine;

namespace Inputs
{
    //todo when merging: destroy this file
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