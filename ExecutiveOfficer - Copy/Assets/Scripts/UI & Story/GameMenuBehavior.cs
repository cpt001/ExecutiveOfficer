using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuBehavior : MonoBehaviour
{
    public GameObject gameMenu;
    public GameObject pauseMenu;

    private bool pauseActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseActive = true;
        }

        if (pauseActive)
        {
            gameMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else
        {
            gameMenu.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        pauseActive = false;
    }

    public void DisplaySettings()
    {

    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
