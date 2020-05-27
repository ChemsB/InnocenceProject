using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warps : MonoBehaviour
{
    //variable to select the point from where the character will travel
    public GameObject target;


    private void Awake()
    {
        //to eliminate the sprites during the in game course
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    /// <summary>
    /// When this event occurs, the player's character gets warped into the new zone
    /// </summary>
    /// <param name="collision">The point where the warp will occur</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if(collision.gameObject.tag == "Player")
        {            
            collision.transform.position = target.transform.GetChild(0).transform.position;
        }
    }

}
