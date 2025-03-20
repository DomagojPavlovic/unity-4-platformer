using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public static float PLAYER_BOUNCE_ON_KILL_MULTIPLIER = 0.7f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.GetComponent<PlayerHealth>())
        {
            return;
        }
        if(collision.otherCollider.GetType() == typeof(CapsuleCollider2D))
        {
            Die();
            collision.gameObject.GetComponent<PlayerMovement>().AddForceUp(PLAYER_BOUNCE_ON_KILL_MULTIPLIER);
        }
        else if (collision.otherCollider.GetType() == typeof(CircleCollider2D))
        {
            collision.gameObject.GetComponent<PlayerHealth>().GetHit();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
