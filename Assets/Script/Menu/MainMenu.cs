using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    void Start()
    {
        startButton.onClick.AddListener(OnStartPressed);
    }

    private void OnStartPressed()
    {
        SceneManager.LoadScene("HorseSpeeder");
    }

    private void OnExitPressed()
    {
        Application.Quit();
    }
}
