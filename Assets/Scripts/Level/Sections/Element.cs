using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnOffset;
    [SerializeField] private Vector3 _rotation;

    [Header("UI")]
    [SerializeField] private Sprite _image;
    [SerializeField] private string _name;

    public Vector3 SpawnOffset => _spawnOffset;
    public Vector3 Rotation => _rotation;

    public Sprite Image => _image;
    public string Name => _name;

    public virtual void Visit(CharacterBase character) { }
}
