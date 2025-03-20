using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : Manager<InputManager>
{
    //debug


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            LevelManager.instance.LoadNextLevel();
        }
    }
}
