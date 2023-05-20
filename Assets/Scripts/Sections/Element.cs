using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnOffset;

    public Vector3 SpawnOffset => _spawnOffset;
}
