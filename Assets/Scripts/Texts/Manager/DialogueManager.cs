using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    //the public object from game where the dialogs occurs
    public GameObject dBox;
    //the text showed to player
    public Text dText;
    //variable to control if dbox must be shown or not
    public bool dialogActive;

    //Array to charge long text dialogs
    public string[] dialogLines;

    public int currentLine;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(dialogActive && Input.GetKeyDown(KeyCode.Space))
        {

            
            currentLine++;

        }

        if(currentLine >= dialogLines.Length)
        {
           
            //this lines hide the textbox in case of come to the end of the dialog lines
            dBox.SetActive(false);
            dialogActive = false;

            currentLine = 0;
        }

        if(dialogLines.Length > 0)
        {
            dText.text = dialogLines[currentLine];
        }
        

    }


    /// <summary>
    /// This method makes sure that dialogue becomes visible to player
    /// </summary>
    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
    }
}
