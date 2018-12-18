using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_CharMove : MonoBehaviour {
    //public is access modifier.
    //class is warehouse

    //Player Movement Var
    public int MoveSpeed;
    public float JumpHeight;
    private bool doubleJump;

    //Player grounded Variables
    //transforms is moving, like rotatio, scaling, to see if you are on the ground
    public Transform groundCheck;
    //to see that player is toching the ground
    public float groundChechRadius;
    //create a layer to define theb ground
    public LayerMask whatIsGround;
    //on ot off, true ot false
    public bool grounded;

    //Non-Stick Player
    private float moveVelocity;

    //animations
    public Animator animator;

	// Use this for initialization
	void Start () {
        //animation reset
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
	}

    //void means no return type for method
    //happens before update
	void FixedUpdate()
	{
        //setting the var ground to the physics, and what is ground
        //fixedupdate happens every cycle, so if you put it in start, the computer would onlu check once if the char is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundChechRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {

        //This code makes the character jump
        //has to be on the ground, and the key is pushed
        if (Input.GetKeyDown (KeyCode.Space) && grounded)
        {
            Jump();
            animator.SetBool("isJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
            animator.SetBool("isJumping", true);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Jump();
            animator.SetBool("isJumping", true);
        }

        //double jump
        //every time PC touches ground, resets animation
        if (grounded)
        {
            doubleJump = false;
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown (KeyCode.Space)&& !doubleJump && !grounded)
        {
            Jump();
            doubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.W) && !doubleJump && !grounded)
        {
            Jump();
            doubleJump = true;
        }
        //This code makes the char move from side to side
        if (Input.GetKey (KeyCode.D))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = MoveSpeed;
            animator.SetBool("isWalking", true);
        }
        else if(Input.GetKeyUp (KeyCode.D)){
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -MoveSpeed;
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = MoveSpeed;
            animator.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", false);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -MoveSpeed;
                animator.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("isWalking", false);
        }


        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        //Player Flip
        //change the number before f when I change scale
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1.5f, 1.5f, 0.3f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-1.5f, 1.5f, 0.3f);


        //Non-Stick Player
        //changing this means it will go a constant x to the right
        moveVelocity = 0f;

    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        animator.SetBool("isJumping", true);
    }
}
