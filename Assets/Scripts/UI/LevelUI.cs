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

    private void Start()
    {
        _startButton.onClick.AddListener(ClickStartButton);
        _restartButton.onClick.AddListener(ClickRestartButton);
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
        OnStartButtonClicked?.Invoke();
    }

    private void ClickRestartButton()
    {
        OnRestartButtonClicked?.Invoke();
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
