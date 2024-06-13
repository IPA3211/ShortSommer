using UnityEngine;

// 이전에 가직고 있던 InputStruct와 비교해서 Start, Perform, Cancel 구별
public class InputEventHandler
{
    InputStruct lastStruct;

    public InputEvent<Vector2> Move;
    public InputEvent<Vector3> Aimming;
    public InputEvent<Vector3> Fire;
    public InputEvent<bool> Jump;
    public InputEvent<bool> Sprint;
    public InputEvent<bool> Interact;

    public void InputEventCheckLoop(InputStruct newInputStruct)
    {
        if (lastStruct.MoveDir != newInputStruct.MoveDir && lastStruct.MoveDir == Vector2.zero) { Move.OnStarted(newInputStruct.MoveDir); }
        else if (newInputStruct.MoveDir != Vector2.zero) { Move.OnPerformed(newInputStruct.MoveDir); }
        else if (lastStruct.MoveDir != newInputStruct.MoveDir && newInputStruct.MoveDir == Vector2.zero) { Move.OnCanceled(newInputStruct.MoveDir); }

        if (lastStruct.AimDir != newInputStruct.AimDir && lastStruct.AimDir == Vector3.zero) { Aimming.OnStarted(newInputStruct.AimDir); }
        else if (newInputStruct.AimDir != Vector3.zero) { Aimming.OnPerformed(newInputStruct.AimDir); }
        else if (lastStruct.AimDir != newInputStruct.AimDir && newInputStruct.AimDir == Vector3.zero) { Aimming.OnCanceled(newInputStruct.AimDir); }

        if (lastStruct.Fire != newInputStruct.Fire && lastStruct.Fire == Vector3.zero) { Fire.OnStarted(newInputStruct.Fire); }
        else if (newInputStruct.Fire != Vector3.zero) { Fire.OnPerformed(newInputStruct.Fire); }
        else if (lastStruct.Fire != newInputStruct.Fire && newInputStruct.Fire == Vector3.zero) { Fire.OnCanceled(newInputStruct.Fire); }

        if (lastStruct.Jump != newInputStruct.Jump && lastStruct.Jump == false) { Jump.OnStarted(newInputStruct.Jump); }
        else if (newInputStruct.Jump == true) { Jump.OnPerformed(newInputStruct.Jump); }
        else if (lastStruct.Jump != newInputStruct.Jump && lastStruct.Jump == true) { Jump.OnCanceled(newInputStruct.Jump); }

        if (lastStruct.Sprint != newInputStruct.Sprint && lastStruct.Sprint == false) { Sprint.OnStarted(newInputStruct.Sprint); }
        else if (newInputStruct.Sprint == true) { Sprint.OnPerformed(newInputStruct.Sprint); }
        else if (lastStruct.Sprint != newInputStruct.Sprint && lastStruct.Sprint == true) { Sprint.OnCanceled(newInputStruct.Sprint); }

        if (lastStruct.Interact != newInputStruct.Interact && lastStruct.Interact == false) { Interact.OnStarted(newInputStruct.Interact); }
        else if (newInputStruct.Interact == true) { Interact.OnPerformed(newInputStruct.Interact); }
        else if (lastStruct.Interact != newInputStruct.Interact && lastStruct.Interact == true) { Interact.OnCanceled(newInputStruct.Interact); }

        lastStruct = newInputStruct;
    }
}
