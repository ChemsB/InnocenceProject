using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    private int menuID = 0;
    private static GameObject[] menuPanels;
    private static GameObject loginMenu;
    private static GameObject mainMenuPanel;
    private static GameObject registerMenu;
    private static GameObject optionsPanel;
    private static GameObject characterSelectPanel;
    private static GameObject controlsMenu;
    private static GameObject showMessage;

    //Load and find all aplication menus
    void Start()
    {
        menuPanels = GameObject.FindGameObjectsWithTag("MenuTag");

        loginMenu = GameObject.Find("LoginMenu"); //0
        registerMenu = GameObject.Find("RegisterMenu"); //1
        mainMenuPanel = GameObject.Find("MainMenu");//2
        characterSelectPanel = GameObject.Find("CharacterSelector");//3
        optionsPanel = GameObject.Find("OptionMenu");//4
        controlsMenu = GameObject.Find("Controls");
        showMessage = GameObject.Find("Message");

        switchToMenu(menuID);
    }

    /// <summary>
    /// Change menu in a correct id
    /// </summary>
    /// <param name="menuID">menu id to changed</param>
    public static void switchToMenu(int menuID)
    {

        foreach (GameObject panel in menuPanels)
        {
            panel.gameObject.SetActive(false);
        }

        switch (menuID)
        {
            case 0:
                PlayerPrefs.SetInt("oldWindow", 0);
                loginMenu.gameObject.SetActive(true); //Active Login Menu
                break;
            case 1:
                PlayerPrefs.SetInt("oldWindow", 1);
                registerMenu.gameObject.SetActive(true); //Active register menu
                break;
            case 2:
                PlayerPrefs.SetInt("oldWindow", 2);
                mainMenuPanel.gameObject.SetActive(true); //Active main menu
                break;
            case 3:
                PlayerPrefs.SetInt("oldWindow", 3);
                characterSelectPanel.gameObject.SetActive(true); //Active character Menu Selector
                break;
            case 4:
                PlayerPrefs.SetInt("oldWindow", 4);
                optionsPanel.gameObject.SetActive(true); //Active Options Menu
                break;
            case 5:
                PlayerPrefs.SetInt("oldWindow",5);
                controlsMenu.gameObject.SetActive(true); //Active Options Menu
                break;
            case 6:
                showMessage.gameObject.SetActive(true); //Active message
                break;
        }
    }
}
