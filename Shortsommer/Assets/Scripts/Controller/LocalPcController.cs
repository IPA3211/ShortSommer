using UnityEngine;
using UnityEngine.InputSystem;

public class LocalPcController
    : MonoBehaviour, LocalInput.IPlayerActions, IController
{
    LocalInput playerInput;

    Vector2 moveVector2 = Vector2.zero;
    bool isAiming = false;
    bool isFiring = false;

    IControllee controllee = null;
    public IControllee Controllee => throw new System.NotImplementedException();

    public void AttachControllee(IControllee controllee)
    {
        if (controllee != null)
        {
            DetachControllee();
        }

        this.controllee = controllee;

    }
    public void DetachControllee()
    {
        if (controllee == null) return;

        controllee = null;
    }

    public void Awake()
    {
        playerInput = new LocalInput();
        playerInput.Player.Enable();
        playerInput.Player.AddCallbacks(this);
    }

    void FixedUpdate()
    {
        CursorCheck();
    }

    void CursorCheck()
    {
        if (isAiming || isFiring)
        {
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out hit))
            {
                if(isAiming) controllee.Aiming(hit.point);
                if(isFiring) controllee.Fire(hit.point);
            }
        }

        if (!isAiming) controllee.Aiming(Vector3.zero);
        if (!isFiring) controllee.Fire(Vector3.zero);

        controllee.Move(moveVector2);
    }

    public void OnAiming(InputAction.CallbackContext context)
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
            controllee.Interact(true);
        }

        if (context.canceled)
        {
            controllee.Interact(false);
        }
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            controllee.Jump(true);
        }

        if (context.canceled)
        {
            controllee.Jump(false);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveVector2 = context.ReadValue<Vector2>();
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            controllee.Sprint(true);
        }

        if (context.canceled)
        {
            controllee.Sprint(false);
        }
    }

}
