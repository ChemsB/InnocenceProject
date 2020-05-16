using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowFailMessage : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject panel;
    public string messageToDisplay;

    void Start()
    {
        
        panel.GetComponent<TextMeshProUGUI>().SetText(messageToDisplay);
    }
}

