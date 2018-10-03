using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace Spawners.CoinSpawners
{
    /// <summary>
    /// CollectiblesSpawnersController is a component that places a collectible spawner on target position.
    /// It must be called from the static Controller of the class CollectibleSpawnerHandler. After a collectible
    /// spawner has been placed, there will be a delay shorter enough to let the ECS Systems deal with the instantiates.
    /// After this delay is passed, however, the spawner placed will be reset and replaced on the SpawnersController's
    /// position.
    ///
    /// Note that a short number of childrens of the GameObject of the CollectiblesSpawnersController
    /// may bring cases where the spawner will just not be placed. This would be due to the fact that no spawners would
    /// be Free at the frame where the CollectiblesSpawnersController was called.
    /// </summary>
    public class CollectiblesSpawnersController : MonoBehaviour
    {
        private const int PLACE_TAKEN_VALUE = -1;
        private const int PLACE_FREE_VALUE = 1;
        private const float TIME_BEFORE_RESET = 0.25f;
        private CollectiblesSpawner[] collectiblesSpawnersTab;
        private int[] spawnersIndexTab;

        private struct SpawnerToReset
        {
            public int Index;
            public float TimeLeft;
        }

        private List<SpawnerToReset> spawnersToReset;

        private void Awake()
        {
            InitializeCollections();

            VerifyCollections();
        }

        private void InitializeCollections()
        {
            collectiblesSpawnersTab = GetComponentsInChildren<CollectiblesSpawner>();
            spawnersIndexTab = new int[collectiblesSpawnersTab.Length];

            for (int i = 0; i < collectiblesSpawnersTab.Length; ++i)
            {
                spawnersIndexTab[i] = PLACE_FREE_VALUE;
            }

            spawnersToReset = new List<SpawnerToReset>();
        }

        private void VerifyCollections()
        {
            if (collectiblesSpawnersTab.Length <= 0)
            {
                throw new ArgumentException("No " + typeof(CollectiblesSpawner).Name + " found in childrens!");
            }
        }

        private void TakeSpawner(int index)
        {
            spawnersIndexTab[index] = PLACE_TAKEN_VALUE;
        }

        private void FreeSpawner(int index)
        {
            spawnersIndexTab[index] = PLACE_FREE_VALUE;
        }

        private bool IndexIsValid(int index)
        {
            return index >= 0;
        }

        private int GetSpawnerFreeIndex()
        {
            for (int i = 0; i < spawnersIndexTab.Length; ++i)
            {
                if (spawnersIndexTab[i] == PLACE_FREE_VALUE)
                {
                    return i;
                }
            }

            return -1;
        }

        private void AddSpawnerToReset(int index)
        {
            SpawnerToReset spawnerToReset = new SpawnerToReset();
            spawnerToReset.Index = index;
            spawnerToReset.TimeLeft = Time.time + TIME_BEFORE_RESET;
            spawnersToReset.Add(spawnerToReset);
        }

        /// <summary>
        /// Function wich places a Collectible Spawner to a GameObject's position.
        /// </summary>
        /// <param name="gameObjectToSpawnTo">The GameObject to place the spawner on.</param>
        /// <param name="collectiblesTarget">The GameObject that will recieve the collectibles after their spawn.</param>
        /// <param name="numberOfInstantiates">The number of collectibles that will be spawned at the spawner position.</param>
        public void PlaceASpawnerAt(GameObject gameObjectToSpawnTo, GameObject collectiblesTarget,
            int numberOfInstantiates)
        {
            int index = GetSpawnerFreeIndex();

            if (IndexIsValid(index))
            {
                TakeSpawner(index);
                collectiblesSpawnersTab[index].Spawn(collectiblesTarget, numberOfInstantiates);
                collectiblesSpawnersTab[index].transform.position = gameObjectToSpawnTo.transform.position;
                AddSpawnerToReset(index);
            }
        }

        //todo when merging : remove those serializeField
        [SerializeField] private GameObject spawningPoint;

        [SerializeField] private GameObject endPoint;
        //

        private void Update()
        {
            //todo when merging : remove this part
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CollectibleSpawnerHandler.Controller.PlaceASpawnerAt(spawningPoint, endPoint, Random.Range(25, 200));
            }
            //

            if (spawnersToReset.Count >= 1)
            {
                List<SpawnerToReset> garbageCollector = new List<SpawnerToReset>();

                foreach (SpawnerToReset spawnerToReset in spawnersToReset)
                {
                    if (Time.time >= spawnerToReset.TimeLeft)
                    {
                        collectiblesSpawnersTab[spawnerToReset.Index].transform.position = transform.position;
                        FreeSpawner(spawnerToReset.Index);
                        garbageCollector.Add(spawnerToReset);
                    }
                }

                //Cannot remove "spawnerToReset" inside the first foreach
                foreach (SpawnerToReset spawnerToReset in garbageCollector)
                {
                    spawnersToReset.Remove(spawnerToReset);
                }
            }
        }
    }
}