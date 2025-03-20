using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : Trap
{
    [SerializeField]
    private GameObject hitbox;

    [SerializeField]
    private ParticleSystem particles;

    public void Start()
    {
        particles.Stop();
    }


    public override void Activate()
    {
        hitbox.SetActive(true);
        particles.Play();
    }

    public override void Deactivate()
    {
        hitbox.SetActive(false);
        particles.Stop();
    }
}
