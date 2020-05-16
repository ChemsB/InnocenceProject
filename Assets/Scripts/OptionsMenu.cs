using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    string nick;
    GameObject nickField, lenguage, bloodYes, bloodNo, song;
    public TranslateGame translate;
    void Start()
    {
        initComponents();
    }


    public void restoreElements()
    {
        lenguage.GetComponent<TMP_Dropdown>().value = 0;
        bloodYes.GetComponent<Toggle>().isOn = true;
        bloodNo.GetComponent<Toggle>().isOn = false;
        song.GetComponent<TMP_Dropdown>().value = 0;
        translate.english();

    }


    //TODO APPLY CHANGES TO GAME
    public void applyChanges()
    {

        
    
        if(lenguage.GetComponent<TMP_Dropdown>().value == 0)
        {

            translate.english();

        }
        else if (lenguage.GetComponent<TMP_Dropdown>().value == 1)
        {

            translate.spanish();
        }
        


    }

    void initComponents()
    {
        nick = PlayerPrefs.GetString("nick");
        nickField = GameObject.Find("InputNick");
        lenguage = GameObject.Find("LenguageSelector");
        bloodYes = GameObject.Find("Yes");
        bloodNo = GameObject.Find("No");
        song = GameObject.Find("SongSelector");
        

        nickField.GetComponent<InputField>().text = nick;
        

    }

}
