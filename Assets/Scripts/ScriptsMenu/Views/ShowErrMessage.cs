using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowErrMessage : MonoBehaviour
{
    // Show message

    string errorMessage="";
    int oldMenu;



    private void Update()
    {
        errorMessage = PlayerPrefs.GetString("messageToShow");
        GameObject.Find("PrintMessage").GetComponent<TextMeshProUGUI>().text = errorMessage;
    }


    /// <summary>
    /// Open previous menu in case of show message
    /// </summary>
    public void openOldMenu()
    {
        oldMenu=PlayerPrefs.GetInt("oldWindow");
        MenuManager.switchToMenu(oldMenu);
    }
}
