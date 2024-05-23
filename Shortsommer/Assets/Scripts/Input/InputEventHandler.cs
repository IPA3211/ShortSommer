using UnityEngine;
using UnityEngine.Windows;

// 이전에 가직고 있던 InputStruct와 비교해서 Start, Perform, Cancel 구별
public class InputEventHandler
{
    InputStruct lastStruct;

    public InputEvent<Vector2> Move;
    public InputEvent<Vector3> Aimming;
    public InputEvent<bool> Jump;
    public InputEvent<bool> Sprint;
    public InputEvent<bool> Interact;
    public InputEvent<bool> Fire;

    public void InputEventCheckLoop(InputStruct newInputStruct)
    {
        if (lastStruct.MoveDir != newInputStruct.MoveDir && newInputStruct.MoveDir != Vector2.zero) {Move.OnStarted(newInputStruct.MoveDir); }
        if (lastStruct.AimDir != newInputStruct.AimDir && newInputStruct.AimDir != Vector3.zero) { Aimming.OnStarted(newInputStruct.AimDir); }
        if (lastStruct.Jump != newInputStruct.Jump && newInputStruct.Jump == true) { Jump.OnStarted(newInputStruct.Jump); }
        if (lastStruct.Sprint != newInputStruct.Sprint && newInputStruct.Sprint == true) { Sprint.OnStarted(newInputStruct.Sprint); }
        if (lastStruct.Interact != newInputStruct.Interact && newInputStruct.Interact == true) { Interact.OnStarted(newInputStruct.Interact); }
        if (lastStruct.Fire != newInputStruct.Fire && newInputStruct.Fire == true) { Fire.OnStarted(newInputStruct.Fire); }

        if (lastStruct.MoveDir == newInputStruct.MoveDir && newInputStruct.MoveDir != Vector2.zero) { Move.OnPerformed(newInputStruct.MoveDir); }
        if (lastStruct.AimDir == newInputStruct.AimDir && newInputStruct.AimDir != Vector3.zero) { Aimming.OnPerformed(newInputStruct.AimDir); }
        if (lastStruct.Jump == newInputStruct.Jump && newInputStruct.Jump == true) { Jump.OnPerformed(newInputStruct.Jump); }
        if (lastStruct.Sprint == newInputStruct.Sprint && newInputStruct.Sprint == true) { Sprint.OnPerformed(newInputStruct.Sprint); }
        if (lastStruct.Interact == newInputStruct.Interact && newInputStruct.Interact == true) { Interact.OnPerformed(newInputStruct.Interact); }
        if (lastStruct.Fire == newInputStruct.Fire && newInputStruct.Fire == true) { Fire.OnPerformed(newInputStruct.Fire); }

        if (lastStruct.MoveDir != newInputStruct.MoveDir && newInputStruct.MoveDir == Vector2.zero) { Move.OnCanceled(newInputStruct.MoveDir); }
        if (lastStruct.AimDir != newInputStruct.AimDir && newInputStruct.AimDir == Vector3.zero) { Aimming.OnCanceled(newInputStruct.AimDir); }
        if (lastStruct.Jump != newInputStruct.Jump && newInputStruct.Jump != true) { Jump.OnCanceled(newInputStruct.Jump); }
        if (lastStruct.Sprint != newInputStruct.Sprint && newInputStruct.Sprint != true) { Sprint.OnCanceled(newInputStruct.Sprint); }
        if (lastStruct.Interact != newInputStruct.Interact && newInputStruct.Interact != true) { Interact.OnCanceled(newInputStruct.Interact); }
        if (lastStruct.Fire != newInputStruct.Fire && newInputStruct.Fire != true) { Fire.OnCanceled(newInputStruct.Fire); }

        lastStruct = newInputStruct;
    }
}
