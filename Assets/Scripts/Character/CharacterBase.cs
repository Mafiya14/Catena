using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float distanceThreshold = 0.1f;
    [SerializeField] private float _maximumTimeWithoutColliders;

    public WaypointPath Path { get; private set; }
    public Transform CurrentWaypoint { get; private set; }
    public int CurrentWaypointId { get; private set; } = -1;

    private bool _startCountdown;
    private float _time = 0;
    private bool _canMove;

    public void Init()
    {
        Path = FindObjectOfType<WaypointPath>();
        _canMove = true;
        GetNextWaypoint();
    }

    private void Update()
    {
        if (!_canMove)
            return;

        Move();

        if (_startCountdown)
        {
            PerformCountdown();
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _startCountdown = false;
            _time = 0f;
            Debug.Log("Entering new pipe");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            _startCountdown = true;
            _time = 0f;
            Debug.Log("Exiting pipe");
        }
    }

    private void PerformCountdown()
    {
        _time += Time.deltaTime;
        if (_time > _maximumTimeWithoutColliders)
        {
            _time = 0f;
            _startCountdown = false;
            Debug.Log("fail");
        }
    }
}
