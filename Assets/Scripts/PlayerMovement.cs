using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D playerRigidBody;
    public float speed;
    public float input;
    public bool jumping;
    public float jumpForce;

    public LayerMask groundLayer;
    bool isGrounded;
    public Transform feetPosition;
    public float groundCheckCircle;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);
        if(isGrounded == true && Input.GetButtonDown("Jump"))
        {
            playerRigidBody.velocity = Vector2.up * jumpForce;
        }

    }

    // runs at 50 frames/ sec
    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);  
    }
}
