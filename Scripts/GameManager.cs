using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;

    public bool IsPaused { get; private set; }
    public bool HasEnded { get; private set; }
    
    public void Awake()
    {
        if (Instance != null && Instance != this) {Destroy(gameObject); return; }
        Instance = this;
    }
    
    public void Start()
    {
        HideAll();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    public void Update()
    {
        if (HasEnded) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        if (HasEnded) return;
        IsPaused = true;
        Time.timeScale = 0f;
        if (pauseMenu) pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        IsPaused = false;
        Time.timeScale = 1f;
        if (pauseMenu) pauseMenu.SetActive(false);
    }

    public void TriggerGameOver()
    {
        if (HasEnded) return;
        HasEnded = true;
        Time.timeScale = 0f;
        if (gameOverScreen) gameOverScreen.SetActive(true);
    }

    public void TriggerWin()
    {
        if (HasEnded) return;
        HasEnded = true;
        Time.timeScale = 0f;
        if (winScreen) winScreen.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void HideAll()
    {
        if (pauseMenu) pauseMenu.SetActive(false);
        if (gameOverScreen) gameOverScreen.SetActive(false);
        if (winScreen) winScreen.SetActive(false);
    }
}
