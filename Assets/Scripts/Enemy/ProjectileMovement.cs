using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private bool moveLeft;

    [SerializeField]
    private float speed;

    void Update()
    {
        transform.Translate((moveLeft ? -1 : 1) * speed * Time.deltaTime, 0, 0);
    }

    public void SetDirection(bool moveLeft)
    {
        this.moveLeft = moveLeft;
    }
}
