using UnityEngine;
using UnityEngine.InputSystem;

public class LocalInputManager : MonoBehaviour, LocalInput.IPlayerActions, IInputManager
{
    LocalInput playerInput;
    InputEventHandler inputEventHandler;
    InputStruct input;

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
        inputEventHandler.InputEventCheckLoop(input);
    }

    public void OnAimming(InputAction.CallbackContext context)
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out hit))
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
}