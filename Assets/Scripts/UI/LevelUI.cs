using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public static event Action OnStartButtonClicked;
    public static event Action OnRestartButtonClicked;

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _restartButton;

    private void Start()
    {
        _startButton.onClick.AddListener(ClickStartButton);
        _restartButton.onClick.AddListener(ClickRestartButton);
    }

    private void ClickStartButton()
    {
        OnStartButtonClicked?.Invoke();
    }

    private void ClickRestartButton()
    {
        OnRestartButtonClicked?.Invoke();
    }
}
