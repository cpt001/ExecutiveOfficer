using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour
{
    public GameObject statsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Master");
    }

    public void DisplayStats()  //This is a placeholder. Ideally, it moves its way in and out
    {
        if (statsPanel.activeInHierarchy == true)
        {
            statsPanel.SetActive(false);
        }
        else if (statsPanel.activeInHierarchy == false)
        {
            statsPanel.SetActive(true);
        }
    }
    public void DisplaySettings()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
