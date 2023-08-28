using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectsPool
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private GameObject _healBoxPrefab;
    [SerializeField] private float _delay;
    [SerializeField] private int _healBoxSpawnPercent;

    private GameObject _healBox;
    private float _elapsedTime = 0;
    private int _maxPercent = 100;

    private void Start()
    {
        Initialize(_enemyPrefabs);
        _healBox = Initialize(_healBoxPrefab);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;        

        if (_elapsedTime >= _delay)
        {
            if (Random.Range(0, _maxPercent) > _healBoxSpawnPercent)
            {
                if (TryGetEnemy(out GameObject enemy))
                {
                    _elapsedTime = 0;
                    SetObjectPosition(enemy);
                }
            }
            else
            {
                if (_healBox.activeSelf == false)
                {
                    _elapsedTime = 0;
                    SetObjectPosition(_healBox);
                }
            }
        }
    }

    private void SetObjectPosition(GameObject enemy)
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Count);

        enemy.SetActive(true);
        enemy.transform.position = _spawnPoints[spawnPointNumber].position;
    }

    private GameObject Initialize(GameObject prefab)
    {
        GameObject gameObject = Instantiate(prefab, transform);
        gameObject.SetActive(false);

        return gameObject;
    }
}
