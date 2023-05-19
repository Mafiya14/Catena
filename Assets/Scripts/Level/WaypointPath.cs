using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField] private List<GameObject> _waypoints;
    [SerializeField] private bool _calculatePathAutomatically;

    public List<GameObject> Waypoints => _waypoints;

    public void Init()
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

    public Transform GetNextWaypoint(int waypointId)
    {
        return _waypoints[waypointId + 1].transform;
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
}
