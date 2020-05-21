using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Player2D : MonoBehaviour
{
    public float speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);  
    }

    // Update is called once per frame
    void Update()
    {
        moveA();
        moveW();
        moveD();
        moveS();
    }
    void moveA()
    {
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("RunLeft", true);
            transform.Translate(-speed, 0, 0);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            GetComponent<Animator>().SetBool("RunLeft", false);
        }
    }
    void moveW()
    {
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("RunBack", true);
            transform.Translate(0, speed, 0);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            GetComponent<Animator>().SetBool("RunBack", false);
        }
    }
    void moveD()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("RunRight", true);
            transform.Translate(speed, 0,0);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("RunRight", false);
        }
    }
    void moveS()
    {
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("RunGo", true);
            transform.Translate(0, -speed, 0);
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GetComponent<Animator>().SetBool("RunGo", false);
        }
    }

}
