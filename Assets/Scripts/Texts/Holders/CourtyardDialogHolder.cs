using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourtyardDialogHolder : MonoBehaviour
{
    public string[] dialogueLines;

    private DialogueManager dManager;

    public TextAsset textFile;

    //variable to make this event unique
    private int firstOccur = 0;


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
        if (collision.gameObject.tag == "Player" && firstOccur == 0)
        {
            if (!dManager.dialogActive)
            {
                if (textFile != null)
                {
                    dialogueLines = (textFile.text.Split('\n'));
                }

                dManager.dialogLines = dialogueLines;
                dManager.currentLine = 0;
                dManager.ShowDialogue();
            }

        }

        firstOccur++;

    }
}
