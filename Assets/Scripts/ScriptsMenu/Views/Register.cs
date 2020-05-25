using Assets.Scripts;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{

    private GameObject inputName, inputNick, initPassword, conditions;
    private Model model;
    Player player;

    public void Start()
    {
        initComponents();

    }

    /// <summary>
    /// Inicialize components
    /// </summary>
    private void initComponents()
    {
  
        model = new Model();
        player = new Player();


        inputName = GameObject.Find("InputFieldName");
        initPassword = GameObject.Find("InputFieldPassword");
        inputNick = GameObject.Find("InputFieldNick");
        conditions = GameObject.Find("Conditions"); 
    }


    /// <summary>
    /// Check if all values are corrects and check if conditions are accepted
    /// </summary>
    public void register()
    {

        string name = inputName.GetComponent<InputField>().text;
        string nick= inputNick.GetComponent<InputField>().text;
        string password= initPassword.GetComponent<InputField>().text;


        if ((name == null || name.Length <= 0) || (nick == null || nick.Length <= 0) || (password == null || password.Length <= 0))
        {          
            showMessage("Invalid parameters!");
        }
        else
        {
            if (conditions.GetComponent<Toggle>().isOn)
            {

                if (model.checkNick(nick))
                {
                    showMessage("Nick already exists!");
                }
                else
                {
                    player.Name = name; // add new user data
                    player.Nick = nick;
                    player.Password = password;
                    Debug.Log(player.Password);
                    insertUser(player); // insert user
                    MenuManager.switchToMenu(2); //Open play menu
                }
            }
            else
            {
                showMessage("Please check conditions!");
            }
        }
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

    /// <summary>
    /// Insert new user in a list and set id internaly
    /// </summary>
    /// <param name="player">user to add</param>
    private void insertUser(Player player)
    {
        player.EndGame = false;
        player.Id_videogame=1;
        PlayerPrefs.SetString("nick", player.Nick);
        StartCoroutine(model.insertNewUser(player));
        //model.insertNewUser(player);
    }



}
