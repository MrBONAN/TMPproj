using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 100f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        PlayerControl();
    }

    private void PlayerControl()
    {
        var h = Input.GetAxis("Horizontal");
        rb.velocity = transform.TransformDirection(new Vector3(h, 0, 0) * (speed * Time.fixedDeltaTime) +
                                                   new Vector3(0, rb.velocity.y, 0));
    }
}