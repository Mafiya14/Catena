using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    public static event Action OnStartButtonClicked;

    [SerializeField] private Button _startButton;

    private void Start()
    {
        _startButton.onClick.AddListener(ClickStartButton);
    }

    private void ClickStartButton()
    {
        OnStartButtonClicked?.Invoke();
    }
}
