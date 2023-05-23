using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _quitButton;

    private readonly int _startSceneIndex = 0;

    private void OnEnable()
    {
        Time.timeScale = 0;    
    }

    private void Start()
    {
        _continueButton.onClick.AddListener(() =>
        {
            EventBus.OnAnyButtonClicked?.Invoke();
            gameObject.SetActive(false);
        });
        _quitButton.onClick.AddListener(() =>
        {
            EventBus.OnAnyButtonClicked?.Invoke();
            SceneManager.LoadScene(_startSceneIndex);
        });
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
