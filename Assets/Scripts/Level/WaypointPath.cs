using System;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private List<GameObject> _waypoints;

    public List<GameObject> Waypoints => _waypoints;

    private List<Container> _containers = new();

    public void Init()
    {
        _containers.AddRange(FindObjectsOfType<Container>());
    }

    private void OnEnable()
    {
        LevelUI.OnStartButtonClicked += HideAllContainers;
    }

    private void OnDisable()
    {
        LevelUI.OnStartButtonClicked -= HideAllContainers;
    }

    private void HideAllContainers()
    {
        foreach (var container in _containers)
        {
            container.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        foreach (var waypoint in _waypoints)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(waypoint.transform.position, 1f);
        }

        Gizmos.color = Color.red;
        for (int i = 0; i < _waypoints.Count - 1; i++)
        {
            Gizmos.DrawLine(_waypoints[i].transform.position, _waypoints[i + 1].transform.position);
        }
    }

    public Transform GetNextWaypoint(int waypointId)
    {
        return _waypoints[waypointId + 1].transform;
    }
}
