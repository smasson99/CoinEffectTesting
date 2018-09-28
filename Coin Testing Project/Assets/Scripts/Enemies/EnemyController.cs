using Spawners.CoinSpawners;
using UnityEngine;

namespace Enemies
{
    //todo when merging: destroy this file
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private GameObject player = null;

        private void OnDestroy()
        {
            CollectibleSpawnerHandler.Controller.PlaceASpawnerAt(transform.root.gameObject, player,
                Random.Range(10, 100));
        }
    }
}