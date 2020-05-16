using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{

    private GameObject inputName, inputNick, conditions;
    public GameObject displayMessage;
    public TextMeshProUGUI messageToDisplay;

    private DatabaseConnection dbConnect;



    public void Start()
    {


        dbConnect = new DatabaseConnection();



        inputName = GameObject.Find("InputFieldName");
        inputNick = GameObject.Find("InputFieldNick");
        conditions = GameObject.Find("Conditions");
    }



    public void register(GameObject mainMenu)
    {

        string name = inputName.GetComponent<InputField>().text;
        string nick = inputNick.GetComponent<InputField>().text;

        if ((name == null || name.Length <= 0) || (nick == null || nick.Length <= 0))
        {

            
            showErrMessage("Invalid parameters!");

        }
        else
        {

            if (conditions.GetComponent<Toggle>().isOn)
            {

                if (dbConnect.CheckNick(nick))
                {
                    showErrMessage("Nick already exists!");
                }
                else
                {
                    PlayerPrefs.SetString("nick", nick);
                    this.gameObject.SetActive(false);
                    mainMenu.SetActive(true);
                }


            }
            else
            {
                showErrMessage("Please check conditions!");
            }
        }
    }

    private void showErrMessage(string message)
    {
        this.gameObject.SetActive(false);
        displayMessage.SetActive(true);
        messageToDisplay.text = message;
    }


}
