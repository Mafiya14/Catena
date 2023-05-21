using UnityEngine;
using System;

public abstract class CharacterBase : MonoBehaviour
{
    public static event Action OnGameFailed;
    public static event Action OnFinishReached;

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
        if (other.gameObject.layer == (int)Layers.Pipe)
        {
            ResetCountdown();
        }

        if (other.gameObject.layer == (int)Layers.Finish)
        {
            ResetCountdown();
            WinGame();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == (int)Layers.Pipe)
        {
            _startCountdown = true;
            _time = 0f;
        }
    }

    private void PerformCountdown()
    {
        _time += Time.deltaTime;
        if (_time > _maximumTimeWithoutColliders)
        {
            FailGame();
        }
    }

    private void FailGame()
    {
        ResetCountdown();
        _canMove = false;
        OnGameFailed?.Invoke();
    }

    private void WinGame()
    {
        ResetCountdown();
        _canMove = false;
        OnFinishReached?.Invoke();
    }

    private void ResetCountdown()
    {
        _time = 0f;
        _startCountdown = false;
    }
}
