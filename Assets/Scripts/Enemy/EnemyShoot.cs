using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float shotCooldown;

    private bool shotOnCooldown = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>() && !shotOnCooldown)
        {
            LocateAndShoot();
        }
    }

    private void LocateAndShoot()
    {
        Vector3 playerPosition = PlayerManager.instance.GetPlayerTransform().position;
        Shoot(transform.position.x > playerPosition.x);
        shotOnCooldown = true;
        Invoke(nameof(ResetShotCooldown), shotCooldown);
    }

    private void ResetShotCooldown()
    {
        shotOnCooldown = false;
    }


    private void Shoot(bool shootLeft)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.GetComponent<ProjectileMovement>().SetDirection(shootLeft);
    }
}
