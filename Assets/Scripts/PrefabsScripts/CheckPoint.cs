using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Save game at specific points

public class CheckPoint : MonoBehaviour
{
    //text to show when game is saving
    public GameObject text; 
  

    void Start()
    {
        text.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Check if user is in save area
    /// </summary>
    /// <param name="collision">object that acts as an event trigger</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ShowMessage(2));
        }
    }

    /// <summary>
    /// Show message for a seconds
    /// </summary>
    /// <param name="delay">seconds to active </param>
    IEnumerator ShowMessage(float delay)
    {
        text.SetActive(true);
        yield return new WaitForSeconds(delay);
        text.SetActive(false);
    }


}
