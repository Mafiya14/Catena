using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElectricitiesLevels : MonoBehaviour
{
    [SerializeField] private int _sceneLevel1;
    [SerializeField] private int _sceneLevel2;
    [SerializeField] private int _startScene;
    [SerializeField] private Button _back;
    [SerializeField] private Button _level1;
    [SerializeField] private Button _level2;

    private void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void Start()
    {
        _back.onClick.AddListener(() => LoadScene(_startScene));
        _level1.onClick.AddListener(() => LoadScene(_sceneLevel1));
        _level2.onClick.AddListener(() => LoadScene(_sceneLevel2));
    }
}
