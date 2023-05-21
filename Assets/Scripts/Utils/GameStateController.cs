using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public static event Action OnTestingStateEntered;

    public enum States
    {
        Preparation,
        Testing
    }

    public States CurrentState { get; private set; }

    [SerializeField] private CharacterBase _characterPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private WaypointPath _waypointPath;

    private void Awake()
    {
        LevelStartup();
    }

    private void OnEnable()
    {
        LevelUI.OnStartButtonClicked += StartGame;
        LevelUI.OnRestartButtonClicked += RestartGame;
    }

    private void OnDisable()
    {
        LevelUI.OnStartButtonClicked -= StartGame;
        LevelUI.OnRestartButtonClicked -= RestartGame;
    }

    private void LevelStartup()
    {
        CurrentState = States.Preparation;
        
        _waypointPath.Init();
        _characterPrefab.transform.position = _spawnPoint.position;
    }

    private void StartGame()
    {
        CurrentState = States.Testing;
        _characterPrefab.gameObject.SetActive(true);
        _characterPrefab.Init();
        OnTestingStateEntered?.Invoke();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
