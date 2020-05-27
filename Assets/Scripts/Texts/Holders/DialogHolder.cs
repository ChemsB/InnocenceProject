using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{
    
    public string[] dialogueLines;

    private DialogueManager dManager;

    public TextAsset textFile;

    // Start is called before the first frame update
    void Start()
    {
        dManager = FindObjectOfType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space)) 
            {
                
                if (!dManager.dialogActive)
                {

                    if(textFile != null)
                    {
                        dialogueLines = (textFile.text.Split('\n'));
                    }



                    dManager.dialogLines = dialogueLines;
                    dManager.currentLine = 0;
                    dManager.ShowDialogue();
                }
    
            }
        }
    }
}
