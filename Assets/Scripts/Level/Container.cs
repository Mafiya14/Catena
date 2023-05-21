using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public Vector3 Rotation { get; private set; }

    private void Start()
    {
        Rotation = transform.rotation.eulerAngles;
    }
}
