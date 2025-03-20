using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Manager<PlayerManager>
{
    private GameObject player;
    private GameObject cam;

    public void InitPlayer(GameObject player)
    {
        this.player = player;
    }

    public void InitCamera(GameObject camera)
    {
        cam = camera;
    }

    public void MovePlayer(Transform transform)
    {
        player.transform.position = transform.position;
    }

    public void MoveCameraToPlayer()
    {
        cam.GetComponent<CameraMovement>().MoveInstantly();
    }

    public Transform GetPlayerTransform()
    {
        return player.transform;
    }
}
