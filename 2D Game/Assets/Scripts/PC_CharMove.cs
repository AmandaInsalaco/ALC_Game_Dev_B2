using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC_CharMove : MonoBehaviour {
    //public is access modifier.
    //class is warehouse

    //Player Movement Var
    public int MoveSpeed;
    public float JumpHeight;

    //Player grounded Variables
    //transforms is moving, like rotatio, scaling, to see if you are on the ground
    public Transform groundCheck;
    //to see that player is toching the ground
    public float groundChechRadius;
    //create a layer to define theb ground
    public LayerMask whatIsGround;
    //on ot off, true ot false
    public bool grounded;

	// Use this for initialization
	void Start () {
		
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
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        {
            Jump();
        }

        //This code makes the char move from side to side
        if (Input.GetKey (KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
    }
}
