using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartGamePanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void Start()
    {
        _restartButton.onClick.AddListener(
            () => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
}
