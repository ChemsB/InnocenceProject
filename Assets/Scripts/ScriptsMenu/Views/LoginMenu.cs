#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class LoginMenu : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject inputNick, inputPassword;
    Model model;

    void Start()
    {
        initComponents();
    }


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
        bool res;
        string nick = inputNick.GetComponent<InputField>().text;
        string password = inputPassword.GetComponent<InputField>().text;

        if(nick.Length<=0 || nick==null || password.Length <= 0 || password == null)
        {
            showMessage("Please input correct values!");
        }
        else
        {
            res = model.login(nick, password);

            if (res)
            {
                showMessage("Welcome!");
                PlayerPrefs.SetString("mode", "Online");
                PlayerPrefs.SetString("nick", nick);
                MenuManager.switchToMenu(2);
            }
            else
            {
                showMessage("wrong credentials!");
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

        #if UNITY_EDITOR
        if (EditorUtility.DisplayDialog("Wait!", "If you play offline you will not be able to " +
            "share your scores, are you sure? ", "Yes", "No"))
        {
            PlayerPrefs.SetString("mode", "Offline");
            MenuManager.switchToMenu(2);
        }
        #endif


    }


    /// <summary>
    /// Show message
    /// </summary>
    /// <param name="message">message to display</param>
    private void showMessage(string message)
    {
        #if UNITY_EDITOR
        EditorUtility.DisplayDialog("Info", message, "Ok");
        #endif

    }


}
