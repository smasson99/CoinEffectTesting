using UnityEngine;

namespace Spawners.CoinSpawners
{
    /// <summary>
    /// CollectibleValue is a ECS Component class wich contains the data required to the ECS Systems to add gold to the
    /// inventory of the players.
    /// </summary>
    public class CollectibleValue : MonoBehaviour
    {
        [Tooltip("The value of the collectible in gold pieces.")]
        [SerializeField]
        private int valueInGoldPieces = 1;
        
        public int ValueInGoldPieces => valueInGoldPieces;
    }
}