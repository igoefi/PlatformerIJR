using System;
using Unity.Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSetterInPlace : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform[] points;
    [SerializeField] private float _spawnChance;

    private void Awake()
    {
        foreach (var point in points)
        {
            if(Random.value <= _spawnChance)
                Instantiate(prefab, point.position, Quaternion.identity);
        }
    }
}
