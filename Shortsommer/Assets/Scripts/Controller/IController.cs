using System;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public interface IController
{
    InputStruct InputInfo { get; }
}
