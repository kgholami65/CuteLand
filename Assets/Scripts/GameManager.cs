using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas pauseCanvas;
    public int currentLevelIndex;
    public int levelCount;

    private void Awake()
    {
        var instanceCount = FindObjectsOfType<GameManager>().Length;
        if (instanceCount > 1)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            currentLevelIndex = 1;
            levelCount = SceneManager.sceneCountInBuildSettings - 2;
        }
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose Scene");
    }

    public void Win()
    {
        currentLevelIndex++;
        SceneManager.LoadScene("Win Scene");
    }

    public void PauseGame()
    {
        pauseCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        pauseCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
}
