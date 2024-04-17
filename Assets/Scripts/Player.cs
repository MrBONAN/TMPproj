using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 500f;
    public float jumpSpeed = 10f;
    private Rigidbody2D rb;
    private SpriteRenderer texture;
    public bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        texture = GetComponentInChildren<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        PlayerControl();
    }

    private void PlayerControl()
    {
        var h = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (h != 0 && h > 0 == facingRight)
        {
            facingRight = !facingRight;
            texture.flipX = facingRight;
        }
        rb.velocity = transform.TransformDirection(new Vector2(h, rb.velocity.y));
        
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("platform") && Input.GetButton("Jump"))
        {
            rb.velocity = transform.TransformDirection(new Vector2(rb.velocity.x, jumpSpeed));
        }
    }
}