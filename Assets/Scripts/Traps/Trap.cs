using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trap : MonoBehaviour
{
    [SerializeField]
    protected float initialDelay;
    [SerializeField]
    protected float uptime;
    [SerializeField]
    protected float downtime;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().GetHit();
        }
    }

    private void Awake()
    {
        Deactivate();

        InvokeRepeating(nameof(Activate), initialDelay, uptime + downtime);
        InvokeRepeating(nameof(Deactivate), initialDelay + uptime, uptime + downtime);
    }

    public abstract void Activate();
    public abstract void Deactivate();

}
