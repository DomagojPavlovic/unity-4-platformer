using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidBody;

    [SerializeField] 
    float movementAcceleration;
    [SerializeField] 
    float movementMaxSpeed;
    [SerializeField] 
    float jumpSpeed;
    [SerializeField] 
    float midairSlowdown;

    private bool singleJumpedCheck = false;
    private bool doubleJumpedCheck = false;

    private readonly float groundCheckDistance = 0.55f; // +0.05 to char size


    public void MoveRight()
    {
        Move(1f);
    }

    public void MoveLeft()
    {
        Move(-1f);
    }

    public void Move(float magnitude)
    {
        float slow = 1f;
        if (!IsGrounded())
        {
            slow = midairSlowdown;
        } else
        {
            singleJumpedCheck = false;
            doubleJumpedCheck = false;
        }
        rigidBody.AddForce(movementAcceleration * slow * magnitude * Time.deltaTime * Vector2.right, ForceMode2D.Impulse);


        Vector3 movementVector = rigidBody.velocity;
        float saveY = movementVector.y;
        movementVector.y = 0;

        if (movementVector.magnitude > movementMaxSpeed)
        {
            movementVector = movementVector.normalized * movementMaxSpeed;
            movementVector.y = saveY;
            rigidBody.velocity = movementVector;
        }
    }

    public void Jump()
    {
        bool isGrounded = IsGrounded();
        if (isGrounded) 
        {
            singleJumpedCheck = false;
            doubleJumpedCheck = false;
        }
        // check if player walked off so remove one jump from him
        if(!isGrounded && !singleJumpedCheck)
        {
            singleJumpedCheck = true;
        }

        if (!isGrounded && doubleJumpedCheck)
        {
            return;
        }

        AddForceUp();

        if (!singleJumpedCheck)
        {
            singleJumpedCheck = true;
            return;
        }

        if (!doubleJumpedCheck)
        {
            doubleJumpedCheck = true;
            return;
        }
    }

    public void AddForceUp(float multiplier = 1f)
    {
        rigidBody.AddForce(multiplier * jumpSpeed * Vector2.up, ForceMode2D.Impulse);
    }

    public bool IsGrounded()
    {        
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, 1);
    }
}
