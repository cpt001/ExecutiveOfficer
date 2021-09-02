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
            PauseGame();
        }
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        gameMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        gameMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void DisplaySettings()
    {
        Debug.Log("Settings not implemented");
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
