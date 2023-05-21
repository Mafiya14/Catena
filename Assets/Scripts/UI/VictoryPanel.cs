using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryPanel : MonoBehaviour
{
    [SerializeField] private Button _nextSceneButton;
    [SerializeField] private int _nextSceneId;

    private void Start()
    {
        _nextSceneButton.onClick.AddListener(
            () => SceneManager.LoadScene(_nextSceneId));
    }
}
