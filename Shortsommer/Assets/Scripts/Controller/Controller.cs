using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InputEvent
{
    public event Action<object> started;
    public event Action<object> performed;
    public event Action<object> canceled;

    public void OnStarted(object param)
    {
        started?.Invoke(param);
    }
    public void OnPerformed(object param)
    {
        performed?.Invoke(param);
    }
    public void OnCanceled(object param)
    {
        canceled?.Invoke(param);
    }
}

public abstract class Controller : MonoBehaviour, IController
{
    InputStruct lastStruct;
    public virtual InputStruct InputInfo { get; }

    public InputEvent Move;
    public InputEvent Aimming;
    public InputEvent Jump;
    public InputEvent Sprint;
    public InputEvent Interact;
    public InputEvent Fire;

    void FixedUpdate()
    {
        if (lastStruct.MoveDir != InputInfo.MoveDir && InputInfo.MoveDir != Vector2.zero)   { Move.OnStarted(InputInfo.MoveDir); }
        if (lastStruct.AimDir != InputInfo.AimDir && InputInfo.AimDir != Vector3.zero)      { Aimming.OnStarted(InputInfo.AimDir); }
        if (lastStruct.Jump != InputInfo.Jump && InputInfo.Jump == true)                    { Jump.OnStarted(InputInfo.Jump); }
        if (lastStruct.Sprint != InputInfo.Sprint && InputInfo.Sprint == true)              { Sprint.OnStarted(InputInfo.Sprint); }
        if (lastStruct.Interact != InputInfo.Interact && InputInfo.Interact == true)        { Interact.OnStarted(InputInfo.Interact); }
        if (lastStruct.Fire != InputInfo.Fire && InputInfo.Fire == true)                    { Fire.OnStarted(InputInfo.Fire); }

        if (lastStruct.MoveDir == InputInfo.MoveDir && InputInfo.MoveDir != Vector2.zero)   { Move.OnPerformed(InputInfo.MoveDir); }
        if (lastStruct.AimDir == InputInfo.AimDir && InputInfo.AimDir != Vector3.zero)      { Aimming.OnPerformed(InputInfo.AimDir); }
        if (lastStruct.Jump == InputInfo.Jump && InputInfo.Jump == true)                    { Jump.OnPerformed(InputInfo.Jump); }
        if (lastStruct.Sprint == InputInfo.Sprint && InputInfo.Sprint == true)              { Sprint.OnPerformed(InputInfo.Sprint); }
        if (lastStruct.Interact == InputInfo.Interact && InputInfo.Interact == true)        { Interact.OnPerformed(InputInfo.Interact); }
        if (lastStruct.Fire == InputInfo.Fire && InputInfo.Fire == true)                    { Fire.OnPerformed(InputInfo.Fire); }

        if (lastStruct.MoveDir != InputInfo.MoveDir && InputInfo.MoveDir == Vector2.zero)   { Move.OnCanceled(InputInfo.MoveDir); }
        if (lastStruct.AimDir != InputInfo.AimDir && InputInfo.AimDir == Vector3.zero)      { Aimming.OnCanceled(InputInfo.AimDir); }
        if (lastStruct.Jump != InputInfo.Jump && InputInfo.Jump != true)                    { Jump.OnCanceled(InputInfo.Jump); }
        if (lastStruct.Sprint != InputInfo.Sprint && InputInfo.Sprint != true)              { Sprint.OnCanceled(InputInfo.Sprint); }
        if (lastStruct.Interact != InputInfo.Interact && InputInfo.Interact != true)        { Interact.OnCanceled(InputInfo.Interact); }
        if (lastStruct.Fire != InputInfo.Fire && InputInfo.Fire != true)                    { Fire.OnCanceled(InputInfo.Fire); }

        lastStruct = InputInfo;
    }
}
