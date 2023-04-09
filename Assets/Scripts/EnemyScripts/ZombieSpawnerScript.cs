using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EnemyScripts
{
    public class ZombieSpawnerScript : MonoBehaviour
    {
        [SerializeField] private GameObject zombiePrefab;
        [SerializeField]private float spawnRangeX = 10f; 
        [SerializeField]private float spawnRangeZ = 10f; 
        [SerializeField]private float spawnInterval; 

        private bool spawning;

        private void Start()
        {
            StartSpawning();
        }

        public void StartSpawning()
        {
            spawning = true;
            SpawnZombiesAsync();
        }

    
        public void StopSpawning()
        {
            spawning = false;
        }

    
        private async void SpawnZombiesAsync()
        {
            while (spawning)
            {
                float x = Random.Range(transform.position.x - spawnRangeX, transform.position.x + spawnRangeX);
                float z = Random.Range(transform.position.z - spawnRangeZ, transform.position.z + spawnRangeZ);
                Vector3 spawnPos = new Vector3(x, transform.position.y, z);
                Instantiate(zombiePrefab, spawnPos, Quaternion.identity);
                await Task.Delay((int)(spawnInterval * 1000)); 
            }
        }
    }
}
