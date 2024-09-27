using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Vector2 spawnRange;

    private int _minTimeToSpawn;
    private int _maxTimeToSpawn;

    private bool _gameOver;

    private void Start()
    {
        _gameOver = false;
        
        _minTimeToSpawn = (int)spawnRange.x;
        _maxTimeToSpawn = (int)spawnRange.y;
        
        StartCoroutine(SpawnCoroutine());
    }
    
    private IEnumerator SpawnCoroutine()
    {
        while (!_gameOver)
        {
            int randomTime = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);
            yield return new WaitForSeconds(randomTime);

            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject prefab = prefabs[randomIndex];
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}


