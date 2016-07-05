using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuNav : MonoBehaviour {

    //starts the game
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Exits game
    public void QuitGame()
    {
        Application.Quit();
    }
}
