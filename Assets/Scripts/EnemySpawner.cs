using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField, Range(1, 5)] private int _spawnDelay = 1;

    private SpawnPoint[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        Debug.Log("Start spawn");
        Debug.Log($"Spawn points: {_spawnPoints.Length}");

        foreach (SpawnPoint spawnPoint in _spawnPoints)
        {
            Instantiate(_template, spawnPoint.transform.position, Quaternion.identity);

            Debug.Log("Spawn");

            yield return new WaitForSeconds(_spawnDelay);
        }
    }
}
