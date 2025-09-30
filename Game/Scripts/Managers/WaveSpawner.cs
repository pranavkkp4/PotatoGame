using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PotatoGame.Managers
{
    public class WaveSpawner : MonoBehaviour
    {
        [System.Serializable]
        private class WaveDefinition
        {
            public string enemyType;
            public int count;
            public float spawnDelay;
        }

        [SerializeField] private Transform[] spawnPoints;
        [SerializeField] private EnemyRegistry enemyRegistry;

        private readonly Queue<WaveDefinition> waveQueue = new Queue<WaveDefinition>();
        private bool isSpawning;

        public void LoadConfig(TextAsset waveConfig)
        {
            waveQueue.Clear();
            if (waveConfig == null)
            {
                return;
            }

            var wrapper = JsonUtility.FromJson<WaveWrapper>(waveConfig.text);
            if (wrapper == null || wrapper.waves == null)
            {
                Debug.LogError("Failed to parse wave configuration.");
                return;
            }

            foreach (var wave in wrapper.waves)
            {
                waveQueue.Enqueue(wave);
            }

            if (!isSpawning)
            {
                StartCoroutine(SpawnRoutine());
            }
        }

        private IEnumerator SpawnRoutine()
        {
            isSpawning = true;
            while (waveQueue.Count > 0)
            {
                WaveDefinition wave = waveQueue.Dequeue();
                yield return SpawnWave(wave);
            }

            isSpawning = false;
        }

        private IEnumerator SpawnWave(WaveDefinition wave)
        {
            for (int i = 0; i < wave.count; i++)
            {
                SpawnEnemy(wave.enemyType);
                yield return new WaitForSeconds(wave.spawnDelay);
            }
        }

        private void SpawnEnemy(string enemyType)
        {
            if (enemyRegistry == null)
            {
                Debug.LogWarning("WaveSpawner has no enemy registry assigned.");
                return;
            }

            GameObject prefab = enemyRegistry.Resolve(enemyType);
            if (prefab == null)
            {
                Debug.LogError($"Enemy type '{enemyType}' not found in registry.");
                return;
            }

            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(prefab, spawnPoint.position, Quaternion.identity);
        }

        [System.Serializable]
        private class WaveWrapper
        {
            public WaveDefinition[] waves;
        }
    }
}
