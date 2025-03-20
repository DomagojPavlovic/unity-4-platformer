using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    [SerializeField]
    private float lifetime;

    private void Start()
    {
        Invoke(nameof(DestroyProjectile), lifetime);
    }

    public void DestroyProjectile()
    {
        Destroy(gameObject);
        // play animation?
    }
}
