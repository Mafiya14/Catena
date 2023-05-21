using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public static event Action OnStartButtonClicked;
    public static event Action OnRestartButtonClicked;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private GameObject _gameFailedPanel;
    [SerializeField] private GameObject _inventoryPanel;

    private void Start()
    {
        _startButton.onClick.AddListener(ClickStartButton);
        _restartButton.onClick.AddListener(ClickRestartButton);
    }

    private void OnEnable()
    {
        CharacterBase.OnGameFailed += ShowGameFailedPanel;
        GameStateController.OnTestingStateEntered += ClosePreparationUI;
    }

    private void OnDisable()
    {
        CharacterBase.OnGameFailed -= ShowGameFailedPanel;
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
        _gameFailedPanel.SetActive(true);
        _startButton.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);
    }

    private void ClosePreparationUI()
    {
        _inventoryPanel.SetActive(false);
        _startButton.gameObject.SetActive(false);
    }
}
