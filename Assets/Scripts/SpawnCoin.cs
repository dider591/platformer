using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private Transform _coinPnoints;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_coinPnoints.childCount];

        for (int i = 0; i < _coinPnoints.childCount; i++)
        {
            _points[i] = _coinPnoints.GetChild(i);
        }

        Spawn();
    }

    private void Spawn()
    {
        foreach (var point in _points)
        {
            Instantiate(_template, point.position, Quaternion.identity);
        }        
    }
}
