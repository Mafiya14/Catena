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

    private void Start()
    {
        _startButton.onClick.AddListener(ClickStartButton);
        _restartButton.onClick.AddListener(ClickRestartButton);
    }

    private void OnEnable()
    {
        CharacterBase.OnGameFailed += ShowGameFailedPanel;
    }

    private void OnDisable()
    {
        CharacterBase.OnGameFailed -= ShowGameFailedPanel;
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
}
