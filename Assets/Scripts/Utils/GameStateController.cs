using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateController : MonoBehaviour
{
    public enum States
    {
        Preparation,
        Testing
    }

    public static GameStateController Instance;

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
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeState()
    {
        if (CurrentState == States.Preparation)
        {
            CurrentState = States.Testing;
        }
        else
        {
            CurrentState = States.Testing;
        }
    }
}
