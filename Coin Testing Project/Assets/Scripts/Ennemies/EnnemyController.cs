using Spawners;
using UnityEngine;

namespace Ennemies
{
    public class EnnemyController : MonoBehaviour
    {
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
//            CollectibleSpawnerHandler.Spawn(collectiblesSpawner);
        }
    }
}