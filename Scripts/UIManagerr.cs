using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerr : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable()
    {
        Health.OnPlayerDeath += EnableGameOverMenu;
        Time.timeScale = 1f;

    }

    private void OnDisable()
    {
        Health.OnPlayerDeath -= EnableGameOverMenu;
        
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestarLevel()
    {
        SceneManager.LoadScene("Normal");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
