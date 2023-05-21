using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{

    [SerializeField] private GameObject _levels;
    [SerializeField] private int _electricityLevels;
    [SerializeField] private int _hydraulicsLevels;
    [SerializeField] private Button _play;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _electricity;
    [SerializeField] private Button _hidraulics;
   
    private void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    private void OpenMenu()
    {
        _levels.SetActive(true);
    }

    private void Start()
    {
        _play.onClick.AddListener(OpenMenu);
        _exit.onClick.AddListener(Application.Quit);
        _electricity.onClick.AddListener(() => LoadScene(_electricityLevels));
        _hidraulics.onClick.AddListener(() => LoadScene(_hydraulicsLevels));
    }
}
