using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollisionWithPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>())
        {
            return;
        }


        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().GetHit();
        }
        GetComponent<ProjectileLifetime>().DestroyProjectile();
    }
}
