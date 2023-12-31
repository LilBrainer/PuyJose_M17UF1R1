using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float speed = 10f;
    private bool isFacingRight = true;
    public static PlayerController pl;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform roofCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        if (pl == null)
        {
            pl = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (!IsGrounded() && !IsRoofed())
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

        if (IsGrounded() || IsRoofed())
        {
            rb.gravityScale = rb.gravityScale * -1;
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.1f);
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazard" || collision.gameObject.tag == "Enemy")
        {
            LevelManager.instance.GameOver();
            this.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Finish")
        {
            LevelManager.instance.Finish();
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hazard")
        {
            LevelManager.instance.GameOver();
            this.gameObject.SetActive(false);
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
    private bool IsRoofed()
    {
        return Physics2D.OverlapCircle(roofCheck.position, 0.2f, groundLayer);
    }

    private void Flip() { 
    
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) 
        { 
            isFacingRight = !isFacingRight;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    internal static void Reset()
    {
        pl.gameObject.SetActive(true);
        pl.gameObject.transform.position = new Vector3(-10f, -18f);
        //rb.gravityScale *= 1;
    }
}
