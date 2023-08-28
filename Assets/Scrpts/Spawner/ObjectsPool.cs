using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(List<GameObject> prefabs)
    {
        for (int i = 0; i < _capacity; i++)
        {
            int prefabNumber = Random.Range(0, prefabs.Count);

            GameObject enemy = Instantiate(prefabs[prefabNumber], _container.transform);
            enemy.SetActive(false);

            _pool.Add(enemy);
        }
    }

    protected bool TryGetEnemy(out GameObject enemy)
    {
        enemy = _pool.FirstOrDefault(enemy => enemy.activeSelf == false);

        return enemy != null;
    }  
}
