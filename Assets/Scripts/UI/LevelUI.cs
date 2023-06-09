using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public static event Action OnStartButtonClicked;
    public static event Action OnRestartButtonClicked;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private RestartGamePanel _restartGamePanel;
    [SerializeField] private VictoryPanel _victoryPanel;
    [SerializeField] private GameObject _inventoryPanel;
    [Header("Pause")]
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _pausePanel;
    [Header("Info")]
    [SerializeField] private Button _infoButton;
    [SerializeField] private GameObject _infoPanel;

    private void Start()
    {
        _startButton.onClick.AddListener(ClickStartButton);
        _restartButton.onClick.AddListener(ClickRestartButton);
        _infoButton.onClick.AddListener(ClickInfoButton);
        _pauseButton.onClick.AddListener(ClickPauseButton);
    }

    private void OnEnable()
    {
        CharacterBase.OnGameFailed += ShowGameFailedPanel;
        CharacterBase.OnFinishReached += ShowVictoryPanel;
        GameStateController.OnTestingStateEntered += ClosePreparationUI;
    }

    private void OnDisable()
    {
        CharacterBase.OnGameFailed -= ShowGameFailedPanel;
        CharacterBase.OnFinishReached -= ShowVictoryPanel;
        GameStateController.OnTestingStateEntered -= ClosePreparationUI;
    }

    private void ClickStartButton()
    {
        EventBus.OnAnyButtonClicked?.Invoke();
        OnStartButtonClicked?.Invoke();
    }

    private void ClickRestartButton()
    {
        EventBus.OnAnyButtonClicked?.Invoke();
        OnRestartButtonClicked?.Invoke();
    }

    private void ClickInfoButton()
    {
        EventBus.OnAnyButtonClicked?.Invoke();
        _infoPanel.SetActive(!_infoPanel.activeInHierarchy);
    }

    private void ClickPauseButton()
    {
        EventBus.OnAnyButtonClicked?.Invoke();
        _pausePanel.SetActive(!_pausePanel.activeInHierarchy);
    }

    private void ShowGameFailedPanel()
    {
        _restartGamePanel.gameObject.SetActive(true);
        _startButton.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);
    }

    private void ShowVictoryPanel()
    {
        _victoryPanel.gameObject.SetActive(true);
        _startButton.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);
    }

    private void ClosePreparationUI()
    {
        _inventoryPanel.SetActive(false);
        _startButton.gameObject.SetActive(false);
    }
}
