using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolChristmas : MonoBehaviour
{

    //Movement Variables
    public float MoveSpeed;
    public bool MoveRight;

    //Wall Check
    public Transform WallCheck;
    public float WallCheckRadius;
    public LayerMask WhatIsWall;
    private bool HittingWall;

    //edge check
    private bool NotAtEdge;
    public Transform EdgeCheck;


    // Update is called once per frame
    void Update()
    {
        NotAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);

        HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

        //enemy flip
        if (HittingWall || !NotAtEdge)
        {
            MoveRight = !MoveRight;
        }

        if (MoveRight)
        {
            //flipping in 3d space, f because we are using float
            //change the number before the f to change scale, the number should be what the unity transform is
            transform.localScale = new Vector3(-.2f, .2f, 0.03f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        else
        {
            transform.localScale = new Vector3(.2f, .2f, 0.03f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}