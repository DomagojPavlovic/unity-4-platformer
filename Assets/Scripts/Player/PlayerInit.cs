using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    void Start()
    {
        PlayerManager.instance.InitPlayer(gameObject);
    }
}
