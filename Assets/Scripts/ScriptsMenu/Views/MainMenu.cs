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

}
