using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : Controller, InputSystem.IPlayerActions
{
    InputSystem playerInput;
    InputStruct input;

    public override InputStruct InputInfo => input;

    public void OnAimming(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            input.m_fire = true;
        }

        if (context.canceled)
        {
            input.m_fire = false;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            input.m_Interact = true;
        }

        if (context.canceled)
        {
            input.m_Interact = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            input.m_Jump = true;
        }

        if (context.canceled)
        {
            input.m_Jump = false;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input.m_MoveDir = context.ReadValue<Vector2>();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            input.m_Sprint = true;
        }

        if (context.canceled)
        {
            input.m_Sprint = false;
        }
    }

    void Start()
    {
        playerInput = new InputSystem();
        playerInput.Player.Enable();

        playerInput.Player.AddCallbacks(this);
    }
}
