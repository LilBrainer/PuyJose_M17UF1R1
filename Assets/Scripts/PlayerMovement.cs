using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 20f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        IsRunning();

        IsFalling();


        if (Input.GetButtonDown("Jump"))
        {
            Gravity();
        }


        //if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}

        Flip();
    }

    private void IsFalling()
    {
        if (!IsGrounded())
        {
            animator.SetBool("onAir", true);
        }
        else
        {
            animator.SetBool("onAir", false);
        }
    }

    private void IsRunning()
    {
        if (horizontal == 0)
        {
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
    }

    private void Gravity()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (IsGrounded())
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.1f);
            rb.gravityScale = rb.gravityScale * -1;
            rb.rotation += 180;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip() { 
    
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        { 
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
