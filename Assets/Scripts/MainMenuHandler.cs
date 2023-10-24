using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{
   
    

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
