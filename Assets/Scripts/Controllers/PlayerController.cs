using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variable to let the tester decide which speed is optimal to movement
    public float speed;

    //Private animator to make sure don't make any changes from Unity
    private Animator anim;
    private Rigidbody2D myRigdbody;
    private bool playerMoving;
    private Vector2 lastMove;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myRigdbody = GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        //to make sure the player stops moving, assign false value to boolean to restart
        playerMoving = false;

        //conditional to detect if the movement is horizontal (X Axis)
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        //conditional to detect if the movement is vertical (Y Axis)
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);

    }


}
