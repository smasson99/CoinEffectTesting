using System.CodeDom.Compiler;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Spawners.CoinSpawners
{
    public class CollectiblesSpawnersController : MonoBehaviour
    {
        private const int PLACE_TAKEN_VALUE = 1;
        private const int PLACE_FREE_VALUE = 1;
        private const float TIME_BEFORE_RESET = 0.25f;
        private CollectiblesSpawner[] collectiblesSpawnersTab = null;
        private int[] spawnersIndexTab = null;

        private struct SpawnerToReset
        {
            public int Index;
            public float TimeLeft;
        }

        private List<SpawnerToReset> spawnersToReset;
        
        private void Awake()
        {
            InitialiseCollections();

            if (collectiblesSpawnersTab.Length <= 0)
            {
                Debug.Log("No spawners found in childrens!");
            }
        }

        private void InitialiseCollections()
        {
            collectiblesSpawnersTab = GetComponentsInChildren<CollectiblesSpawner>();
            spawnersIndexTab = new int[collectiblesSpawnersTab.Length];

            for (int i = 0; i < collectiblesSpawnersTab.Length; ++i)
            {
                spawnersIndexTab[i] = PLACE_FREE_VALUE;
            }
            
            spawnersToReset = new List<SpawnerToReset>();
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
                if (spawnersIndexTab[i] > 0)
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

        public void PlaceASpawnerAt(GameObject targetToSpawn, GameObject coinsTarget)
        {
            int index = GetSpawnerFreeIndex();
            
            if (IndexIsValid(index))
            {
                TakeSpawner(index);
                collectiblesSpawnersTab[index].Spawn(coinsTarget);
                collectiblesSpawnersTab[index].transform.position = targetToSpawn.transform.position;
                AddSpawnerToReset(index);
            }
        }

        [SerializeField] private GameObject spawningPoint = null;
        [SerializeField] private GameObject endPoint = null;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CollectibleSpawnerHandler.Controller.PlaceASpawnerAt(spawningPoint, endPoint);
            }

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

                foreach (SpawnerToReset spawnerToReset in garbageCollector)
                {
                    spawnersToReset.Remove(spawnerToReset);
                }
            }
        }
    }
}