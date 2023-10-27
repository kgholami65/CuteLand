using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class WinScreenHandler : MonoBehaviour
{
    [SerializeField] private Button continueButton;
    private GameManager _gameManager;
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        if (_gameManager.currentLevelIndex >= _gameManager.levelCount && continueButton != null)
            continueButton.gameObject.SetActive(false);
    }


    public void RestartLevel()
    {
        SceneManager.LoadScene("Level" + _gameManager.currentLevelIndex);
    }

    public void Continue()
    {
        SceneManager.LoadScene("Level" + _gameManager.currentLevelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
