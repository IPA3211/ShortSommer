using UnityEngine;
using UnityEngine.InputSystem;

public class LocalInputManager : MonoBehaviour, LocalInput.IPlayerActions, IInputManager
{
    LocalInput playerInput;
    InputEventHandler inputEventHandler;
    InputStruct input;

    bool isAiming = false;
    bool isFiring = false;

    public InputStruct InputInfo => input;
    public InputEventHandler InputEventHandler => inputEventHandler;

    public void Awake()
    {
        playerInput = new LocalInput();
        playerInput.Player.Enable();
        playerInput.Player.AddCallbacks(this);

        inputEventHandler = new InputEventHandler();
    }

    void FixedUpdate()
    {
        CursorCheck();
        inputEventHandler.InputEventCheckLoop(input);
    }

    void CursorCheck()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (isAiming)
        {
            if (Physics.Raycast(ray, out hit))
            {
                input.m_AimDir = hit.point;
            }
        }
        else
        {
            input.m_AimDir = Vector3.zero;
        }

        if (isFiring)
        {
            if (Physics.Raycast(ray, out hit))
            {
                input.m_fireDir = hit.point;
            }
        }
        else
        {
            input.m_fireDir = Vector3.zero;
        }
    }

    public void OnAimming(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isAiming = false;
        }
        else
        {
            isAiming = true;
        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            isFiring = false;
        }
        else
        {
            isFiring = true;
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
}
