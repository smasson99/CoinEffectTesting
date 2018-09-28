using UnityEngine;

namespace Spawners.CoinSpawners
{
    public class CollectibleValue : MonoBehaviour
    {
        [Tooltip("The value of the collectible in gold pieces.")]
        [SerializeField]
        private int valueInGoldPieces = 1;
        
        public int ValueInGoldPieces => valueInGoldPieces;
    }
}