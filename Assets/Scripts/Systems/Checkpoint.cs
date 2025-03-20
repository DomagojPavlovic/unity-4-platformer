using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;

    private bool registered = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerMovement>() && !registered)
        {
            LevelManager.instance.PlayerReachedCheckpoint(transform);
            particles.Play();
            registered = true;
        }
    }

    public void ResetCheckpoint()
    {
        registered = false;
    }
}
