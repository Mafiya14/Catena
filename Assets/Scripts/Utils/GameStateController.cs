using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public static event Action OnTestingStateEntered;
    public static event Action OnPreparationStateEntered;

    public static GameStateController Instance;

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
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        LevelStartup();
    }

    private void OnEnable()
    {
        LevelUI.OnStartButtonClicked += StartGame;
        LevelUI.OnRestartButtonClicked += RestartGame;
        RotatingElement.OnStartAnimationPlayed += SpawnPlayer;
    }

    private void OnDisable()
    {
        LevelUI.OnStartButtonClicked -= StartGame;
        LevelUI.OnRestartButtonClicked -= RestartGame;
        RotatingElement.OnStartAnimationPlayed -= SpawnPlayer;
    }

    private void LevelStartup()
    {
        CurrentState = States.Preparation;
        
        _waypointPath.Init();
        _characterPrefab.transform.position = _spawnPoint.position;
        OnPreparationStateEntered?.Invoke();
    }

    private void StartGame()
    {
        CurrentState = States.Testing;
        OnTestingStateEntered?.Invoke();
    }

    private void SpawnPlayer()
    {
        _characterPrefab.gameObject.SetActive(true);
        _characterPrefab.Init();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
