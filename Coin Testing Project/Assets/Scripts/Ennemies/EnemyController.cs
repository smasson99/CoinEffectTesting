using Spawners;
using Spawners.CoinSpawners;
using UnityEngine;

namespace Ennemies
{
    //todo when merging: destroy this file
    public class EnnemyController : MonoBehaviour
    {
        [SerializeField] private GameObject player = null;

        private CollectiblesSpawner collectiblesSpawner = null;

        private void Awake()
        {
            collectiblesSpawner = GetComponentInChildren<CollectiblesSpawner>();

            if (collectiblesSpawner == null)
            {
                Debug.Log("CollectiblesSpawner not found!");
            }
        }

        private void OnDestroy()
        {
            CollectibleSpawnerHandler.Controller.PlaceASpawnerAt(transform.root.gameObject, player,
                Random.Range(10, 100));
        }
    }
}