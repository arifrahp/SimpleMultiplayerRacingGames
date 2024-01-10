using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayManager : MonoBehaviour
{
    public static PlayManager Instance { get; private set; }

    [SerializeField] GameObject sphere1;
    [SerializeField] GameObject sphere2;
    [SerializeField] AudioSource winAudio;
    public Button player1Ready;
    public Button player2Ready;
    public Button restartButton;
    public Button pauseButton;
    public Button resumeButton;
    public Button returnButton;
    public GameObject gameOverPanel;
    public GameObject playerReadyPanel;
    public bool isGameOver = false;
    private bool player1IsReady = false;
    private bool player2IsReady = false;

    private HorseSpeeder horseSpeeder;
    private PlayerInput playerInput;

    private void Awake()
    {
        sphere1.gameObject.SetActive(true);
        sphere2.gameObject.SetActive(true);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        horseSpeeder = FindObjectOfType<HorseSpeeder>();
        playerInput = FindObjectOfType<PlayerInput>();
    }

    public void Start()
    {
        gameOverPanel.SetActive(false);
        playerReadyPanel.SetActive(true);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
        restartButton.onClick.AddListener(RestartGame);
        returnButton.onClick.AddListener(BackMainMenu);
        Time.timeScale = 0;
        Ready();
    }

    private void Update()
    {
        if(player1IsReady == true && player2IsReady == true)
        {
            StartGame();
        }
        else if (isGameOver == true)
        {
            Time.timeScale = 0;
        }
    }

    public void Ready()
    {
        player1Ready.onClick.AddListener(ReadyPlayer1);
        player2Ready.onClick.AddListener(ReadyPlayer2);
    }

    public void ReadyPlayer1()
    {
        player1IsReady = true;
        player1Ready.gameObject.SetActive(false);
    }
    
    public void ReadyPlayer2()
    {
        player2IsReady = true;
        player2Ready.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        if (!isGameOver)
        {
            isGameOver = true;
            player1IsReady = false;
            player2IsReady = false;

            gameOverPanel.SetActive(true);

            horseSpeeder.enabled = false;
            playerInput.enabled = false;
            horseSpeeder.boostAudio.Stop();
            Time.timeScale = 0;

            winAudio.Play();

            horseSpeeder.enabled = false;
            playerInput.enabled = false;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        player1IsReady = false;
        player2IsReady = false;
        horseSpeeder.enabled = false;
        playerInput.enabled = false;
    }
    
    public void ResumeGame()
    {
        player1Ready.gameObject.SetActive(true);
        player2Ready.gameObject.SetActive(true);
        playerReadyPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }

    private void StartGame()
    {
        playerReadyPanel.SetActive(false);
        Time.timeScale = 1;

        horseSpeeder.enabled = true;
        playerInput.enabled = true;
    }

    /*IEnumerator Countdown(int seconds)
    {
        int count = seconds;
        while (count > 0)
        {
            yield return new WaitForSeconds(1);
            count--;
        }
    }*/
}