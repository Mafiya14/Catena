using UnityEngine;

public class LevelStartup : MonoBehaviour
{
    [SerializeField] private GameStateController _gameStateController;
    [SerializeField] private CharacterBase _characterPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private WaypointPath _waypointPath;

    private void Awake()
    {
        _waypointPath.Init();

        _characterPrefab.transform.position = _spawnPoint.position;
        _characterPrefab.gameObject.SetActive(true);
        _characterPrefab.Init();
    }
}
