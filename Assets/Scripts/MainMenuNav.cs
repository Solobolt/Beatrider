using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuNav : MonoBehaviour {

    //Holds 'Are you sure' screen
    public GameObject areYouSureScreen;

    //starts the game
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Show are you sure screen
    public void ShowSureScreen()
    {
        areYouSureScreen.SetActive(true);
    }

    //Hide are you sure screen
    public void HideSureScreen()
    {
        areYouSureScreen.SetActive(false);
    }

    //Exits game
    public void QuitGame()
    {
        Application.Quit();
    }
}
