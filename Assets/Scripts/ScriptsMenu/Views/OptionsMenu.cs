﻿using System.Collections.Generic;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    private GameObject nickField, lenguage, song;
    string oldNick, newNick;
   
    public TranslateGame translate;
    private List<string> songs;
    private Model model;

   public void Start()
    {
        initComponents();
    }

    //Initialize components
    void initComponents()
    {
        model = new Model();

        PlayerPrefs.SetString("Song", "0");
        //Find elements in option menu
        nickField = GameObject.Find("InputNick");
        lenguage = GameObject.Find("LenguageSelector");
        song = GameObject.Find("SongSelector");


        CheckModePlay(); //Check if is online or offline


        //Display nick when menu is opened
        nickField.GetComponent<InputField>().text = oldNick;


    }

    /// <summary>
    /// Check if player is online or offline
    /// In case of Online user can change nick
    /// In case of Offline user signed default nick and not be changed 
    /// </summary>
    private void CheckModePlay()
    {
        //Check if user is registred or not, in this case show default nick
        if (PlayerPrefs.GetString("mode").Equals("Offline"))
        {
            //In mode offline nick are same all time
            oldNick = "DefaultPlayer01";
            newNick = oldNick;
            nickField.GetComponent<InputField>().enabled = false;
        }
        else
        {
            nickField.GetComponent<InputField>().enabled = true;
            //Recives internaly nick
            oldNick = PlayerPrefs.GetString("nick");

            //Save old nick
            newNick = oldNick;
        }
    }

    /// <summary>
    /// Restore all elements and translate lenguage in english
    /// </summary>
    public void restoreElements()
    {
        lenguage.GetComponent<TMP_Dropdown>().value = 0;
        PlayerPrefs.SetString("Song", "0");
        song.GetComponent<TMP_Dropdown>().value = 0;
        translate.english();

    }

    /// <summary>
    /// Apply all changes
    /// </summary>
    public void applyChanges()
    {
        

        translateLenguage();//translate videogame menu
        newNick = nickField.GetComponent<InputField>().text;

        //if new nick is diferent to old nick, nick has changed
        if (!oldNick.Equals(newNick))
        {
            changeNick();
        }
        PlayerPrefs.SetString("Song", song.GetComponent<TMP_Dropdown>().value.ToString());

    }


    /// <summary>
    /// Translate videogame in spanish or english
    /// </summary>
    private void translateLenguage()
    {
        if (lenguage.GetComponent<TMP_Dropdown>().value == 0)
        {
            translate.english();
        }
        else if (lenguage.GetComponent<TMP_Dropdown>().value == 1)
        {
            translate.spanish();
        }
    }


    /// <summary>
    /// Change user nick in online mode case
    /// </summary>
    private void changeNick()
    {
        bool changeNick;
        changeNick = model.changeNick(oldNick, newNick);

        if (changeNick)
        {
            PlayerPrefs.SetString("nick", newNick);
        }
        else
        {
            nickField.GetComponent<InputField>().text = oldNick;
            showMessage("Nick already exists!");
        }


    }


    /// <summary>
    /// Show error message
    /// </summary>
    /// <param name="message">message to display</param>
    private void showMessage(string message)
    {
        PlayerPrefs.SetString("messageToShow", message);
        MenuManager.switchToMenu(6);
    }

    /// <summary>
    /// Open main menu
    /// </summary>
    public void openMainMenu()
    {
        MenuManager.switchToMenu(2);
    }



}
