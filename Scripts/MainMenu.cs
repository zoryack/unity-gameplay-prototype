using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Normal");
    }
    
    public void MainMenuu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
