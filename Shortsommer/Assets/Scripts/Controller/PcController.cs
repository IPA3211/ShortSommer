using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class PcController : MonoBehaviour, IController
{
    IInputManager inputManager = null;
    IControllee controllee = null;
    public IControllee Controllee => controllee;

    void Awake()
    {
        inputManager = GetComponent<IInputManager>();

        if(inputManager == null)
        {
            Debug.LogWarning("PcController : IInputManager is required.");
        }
    }

    public void AttachControllee(IControllee controllee)
    {
        if (controllee != null)
        {
            DetachControllee();
        }

        this.controllee = controllee;

        inputManager.InputEventHandler.Move.started += controllee.Move;
        inputManager.InputEventHandler.Move.performed += controllee.Move;
        inputManager.InputEventHandler.Move.canceled += controllee.Move;
        inputManager.InputEventHandler.Aimming.performed += controllee.Aimming;
        inputManager.InputEventHandler.Aimming.canceled += controllee.Aimming;

        inputManager.InputEventHandler.Fire.performed += controllee.Fire;
        inputManager.InputEventHandler.Jump.started += controllee.Jump;
        inputManager.InputEventHandler.Sprint.started += controllee.Sprint;
        inputManager.InputEventHandler.Sprint.canceled += controllee.Sprint;
        inputManager.InputEventHandler.Interact.started += controllee.Interact;
    }

    public void DetachControllee()
    {
        if (controllee == null) return;

        inputManager.InputEventHandler.Move.started -= controllee.Move;
        inputManager.InputEventHandler.Move.performed -= controllee.Move;
        inputManager.InputEventHandler.Move.canceled -= controllee.Move;
        inputManager.InputEventHandler.Aimming.performed -= controllee.Aimming;
        inputManager.InputEventHandler.Aimming.canceled -= controllee.Aimming;

        inputManager.InputEventHandler.Fire.performed -= controllee.Fire;
        inputManager.InputEventHandler.Jump.started -= controllee.Jump;
        inputManager.InputEventHandler.Sprint.started -= controllee.Sprint;
        inputManager.InputEventHandler.Sprint.canceled -= controllee.Sprint;
        inputManager.InputEventHandler.Interact.started -= controllee.Interact;

        controllee = null;
    }
}
