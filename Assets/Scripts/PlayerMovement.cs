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
    public Transform sprite;
    public float groundCheckCircle;


    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, groundLayer);

        if (isGrounded)
        {
            Vector3 rotation = sprite.rotation.eulerAngles;
            rotation.z = Mathf.Round(rotation.z / 90) * 90;
            sprite.rotation = Quaternion.Euler(rotation);

            if (Input.GetButtonDown("Jump"))
            {
                playerRigidBody.velocity = Vector2.up * jumpForce;
            }
            
        }
        else
        {
            sprite.Rotate(Vector3.back * 1);
        }

    }


    // runs at 50 frames/ sec
    private void FixedUpdate()
    {
        playerRigidBody.velocity = new Vector2(speed, playerRigidBody.velocity.y);
    }
}
