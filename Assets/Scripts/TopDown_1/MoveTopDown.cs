﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveTopDown : MonoBehaviour
{
    public float tempMoveSpeed = 5f;
    public float moveSpeed = 5f;
    public float runSpeed = 10f;

    public float fallMultiplier = 2.5f;
    public bool isSwinging;
    private bool facingRight;

    // Update is called once per frame
    Rigidbody2D rb;
    public float dashSpeed = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;

    }
    void FixedUpdate()
    {
        Vector3 movementHorizontal = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        transform.position += movementHorizontal * Time.deltaTime * tempMoveSpeed;

        
        Vector3 movementVertical = new Vector3(0 , Input.GetAxis("Vertical"), 0);

        transform.position += movementVertical * Time.deltaTime * tempMoveSpeed;


        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }

        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);


     



    }

    public void Flip(float horizontal)
    {

        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector2 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }

    }

    

}
