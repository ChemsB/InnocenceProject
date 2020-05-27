#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{

    private GameObject inputNick, inputPassword;
    Model model;

    void Start()
    {
        initComponents();
    }

    /// <summary>
    /// Initialize game objects
    /// </summary>
    private void initComponents()
    {
        model = new Model();
        inputNick = GameObject.Find("InputFieldNick");
        inputPassword = GameObject.Find("InputFieldPassword");
    }

    /// <summary>
    /// Login User, find user in a list and set mode to online
    /// </summary>
    public void login()
    {
        int res;
        string nick = inputNick.GetComponent<InputField>().text;
        string password = inputPassword.GetComponent<InputField>().text;

        if(nick.Length<=0 || nick==null || password.Length <= 0 || password == null)
        {
            showMessage("Please input correct values!");
        }
        else
        {
            res = model.login(nick, password);

            if (res==0)
            {
                PlayerPrefs.SetString("mode", "Online");
                PlayerPrefs.SetString("nick", nick);
                MenuManager.switchToMenu(2);
            }
            else if(res==1)
            {
                showMessage("wrong credentials!");
            }
            else
            {
                showMessage("the server is not available, try leter!");
            }
        }

    }

    /// <summary>
    /// Open register panel
    /// </summary>
    public void openRegisterPanel()
    {

        MenuManager.switchToMenu(1);
    }

    /// <summary>
    /// Asign default nick to user and change mode to Offline
    /// </summary>
    public void playOffline()
    {
        PlayerPrefs.SetString("mode", "Offline");
        MenuManager.switchToMenu(2);


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
