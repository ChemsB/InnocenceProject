using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    //The object that camara will follow, in that case the character
    private GameObject followTarget;
    //The coordinates to follow the target
    private UnityEngine.Vector3 targetPos;
    //how fast the camera will go before the player 
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        //Find with default character name, Player + id character + (Clone)
        followTarget = GameObject.Find("Player" + "(Clone)");

        if (followTarget == null)
        {
            followTarget = GameObject.Find("Player");
        }

        targetPos = new UnityEngine.Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        //this lines interpolates the camera where starts and where will it have to be
        transform.position = UnityEngine.Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
