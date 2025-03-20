using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] 
    private GameObject player;

    [SerializeField] 
    private float moveSpeed;
    [SerializeField] 
    private float lookAheadDistance;
    [SerializeField]
    private float lookAheadSpeed;

    private float lookOffset;

    private Rigidbody2D playerRigidBody;

    private void Start()
    {
        lookOffset = 0;
        playerRigidBody = player.GetComponent<Rigidbody2D>();
        MoveInstantly();
    }

    void FixedUpdate()
    {
        lookOffset = Mathf.Lerp(lookOffset, lookAheadDistance * MathF.Sign(playerRigidBody.velocity.x), lookAheadSpeed * Time.deltaTime);
        Vector2 target = new(player.transform.position.x + lookOffset, player.transform.position.y);
            
        transform.position = Vector2.Lerp(transform.position, target, moveSpeed * Time.deltaTime);
        transform.position += new Vector3(0, 0, -1);
    }

    public void MoveInstantly()
    {
        transform.position = player.transform.position;
    }
}
