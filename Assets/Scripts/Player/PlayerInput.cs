using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] InputActionReference leftStickInput;
    [SerializeField] PlayerMovement playerMovement;

    private void Start()
    {
        leftStickInput.asset.Enable();
    }


    void FixedUpdate()
    {
        playerMovement.Move(0);

        Vector2 leftStickInputVector = leftStickInput.action.ReadValue<Vector2>();
        if(leftStickInputVector != Vector2.zero)
        {
            playerMovement.Move(leftStickInputVector.x);
        }

        if (Input.GetKey(KeyCode.A))
        {
            playerMovement.MoveLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerMovement.MoveRight();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerMovement.Jump();
        }
    }
}
