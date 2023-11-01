using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float speed = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;


    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();

        if (sr.flipX == true)
        {
            speed *= -1;
        }

    }

    void Update()
    {
        rb.velocity = transform.right * speed;

        if (sr.flipX == true)
        {
            if (this.gameObject.transform.position.x < 47f)
            {
                this.gameObject.transform.position = new Vector3(83f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            }
        }
        else
        {
            if (this.gameObject.transform.position.x > 83f)
            {
                this.gameObject.transform.position = new Vector3(45f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
            }
        }
    }
}
