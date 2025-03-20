using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInit : MonoBehaviour
{
    void Start()
    {
        PlayerManager.instance.InitCamera(gameObject);
    }
}
