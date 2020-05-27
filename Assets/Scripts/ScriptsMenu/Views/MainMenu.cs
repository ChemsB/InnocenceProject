using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Close application
    public void QuitGame()
    {
       
        Application.Quit();
    }

    //Open Character Selector Menu
    public void openCharactersMenu()
    {
        MenuManager.switchToMenu(3);
    }

    //Open option menu
    public void openOptionsMenu()
    {
        MenuManager.switchToMenu(4);
    }


    //Open login window
    public void openLoginLogoutPanel()
    {
        MenuManager.switchToMenu(0);
    }

    /// <summary>
    /// Open Ranking
    /// </summary>
    public void openRanking()
    {
        if (!PlayerPrefs.GetString("mode").Equals("Offline"))
        {
            SceneManager.LoadScene("ShowRanking");
        }
        else
        {
            showMessage("Please login!");
        }
    }


    /// <summary>
    /// Show message
    /// </summary>
    /// <param name="message">message to display</param>
    private void showMessage(string message)
    {
        PlayerPrefs.SetString("messageToShow", message);
        MenuManager.switchToMenu(6);


    }

}
