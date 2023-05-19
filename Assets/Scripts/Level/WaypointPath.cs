using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private List<GameObject> _waypoints;
    [SerializeField] private bool _calculatePathAutomatically;

    private void Start()
    {
        if (_calculatePathAutomatically)
        {
            CalculatePath();
        }
    }

    private void CalculatePath()
    {
        string waypointTagName = Tags.Waypoint.ToString();
        _waypoints.AddRange(GameObject.FindGameObjectsWithTag(waypointTagName));
    }
}
