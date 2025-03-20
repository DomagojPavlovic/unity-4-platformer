using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] 
    private Rigidbody2D rigidBody;

    [SerializeField] 
    private CircleCollider2D circleCollider;

    private readonly float groundCheckDistance = 0.55f;
    private readonly float leftRightCheckDistance = 0.1f;

    private float direction;

    [SerializeField] float acceleration;

    void Start()
    {
        direction = 1;
    }

    void FixedUpdate()
    {
        if(ChangeDirection())
        {
            direction *= -1;
        }

        transform.Translate(direction * acceleration * Time.deltaTime, 0, 0);
    }

    public bool ChangeDirection()
    {
        float radius = circleCollider.radius;
        Vector2 left = (Vector2) transform.position - new Vector2(radius, 0);
        Vector2 right = (Vector2) transform.position + new Vector2(radius, 0);

        return !Physics2D.Raycast(left, Vector2.down, groundCheckDistance, 1) || 
            !Physics2D.Raycast(right, Vector2.down, groundCheckDistance, 1) || 
            Physics2D.Raycast(right, Vector2.right, leftRightCheckDistance, 1) ||
            Physics2D.Raycast(left, Vector2.left, leftRightCheckDistance, 1);
    }
}
