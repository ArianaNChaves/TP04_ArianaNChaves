using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Vector2 spawnRange;

    private float _minTimeToSpawn;
    private float _maxTimeToSpawn;

    private bool _gameOver;

    private void Start()
    {
        _gameOver = false;
        
        _minTimeToSpawn = spawnRange.x;
        _maxTimeToSpawn = spawnRange.y;
        
        StartCoroutine(SpawnCoroutine());
    }
    
    private IEnumerator SpawnCoroutine()
    {
        while (!_gameOver)
        {
            float randomTime = Random.Range(_minTimeToSpawn, _maxTimeToSpawn);
            Debug.Log(randomTime);
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


