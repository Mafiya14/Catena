using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HydraulicsLevels : MonoBehaviour
{
    [SerializeField] private int _sceneLevel1;
    [SerializeField] private int _sceneLevel2;
    [SerializeField] private int _sceneLevel3;
    [SerializeField] private int _sceneLevel4;
    [SerializeField] private int _sceneLevel5;
    [SerializeField] private int _startScene;
    [SerializeField] private Button _back;
    [SerializeField] private Button _level1;
    [SerializeField] private Button _level2;
    [SerializeField] private Button _level3;
    [SerializeField] private Button _level4;
    [SerializeField] private Button _level5;

    private void LoadScene(int scene)
    {
        EventBus.OnAnyButtonClicked?.Invoke();
        SceneManager.LoadScene(scene);
    }

    private void Start()
    {
        _back.onClick.AddListener(() => LoadScene(_startScene));
        _level1.onClick.AddListener(() => LoadScene(_sceneLevel1));
        _level2.onClick.AddListener(() => LoadScene(_sceneLevel2));
        _level3.onClick.AddListener(() => LoadScene(_sceneLevel3));
        _level4.onClick.AddListener(() => LoadScene(_sceneLevel4));
        _level5.onClick.AddListener(() => LoadScene(_sceneLevel5));
    }
}
