using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float distanceThreshold = 0.1f;

    public WaypointPath Path { get; private set; }
    public Transform CurrentWaypoint { get; private set; }
    public int CurrentWaypointId { get; private set; } = -1;

    public void Init()
    {
        Path = FindObjectOfType<WaypointPath>();
        GetNextWaypoint();
    }

    private void Update()
    {
        Move();
    }

    public virtual void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint.position, moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, CurrentWaypoint.position) < distanceThreshold)
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (CurrentWaypointId == Path.Waypoints.Count - 1)
            return;

        CurrentWaypoint = Path.GetNextWaypoint(CurrentWaypointId);
        CurrentWaypointId++;
    }
}
