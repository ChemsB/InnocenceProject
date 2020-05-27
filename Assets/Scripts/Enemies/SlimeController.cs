using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    //variable to determine the speed of the monster
    public float moveSpeed;

    private Rigidbody2D myRigidbody;
    //variable to control if the move has to start or not
    private bool moving;

    //to charge the deadScene
    public string deadScene;

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection; 

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (moving)
        {

            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection; 

            if(timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }


        } else {

            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                //in this lines we assign random move to the slime monster
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, 0f, 0f);
            }
        }


    }

    /// <summary>
    /// This collision will make the player die
    /// </summary>
    /// <param name="collision">The player</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") 
        {
            SceneManager.LoadScene("YoureDead");
        }
    }

}
