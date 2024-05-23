using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class PcController : MonoBehaviour, IController
{
    IInputManager inputManager = null;
    ICharacter character = null;
    public ICharacter Character => character;

    void Awake()
    {
        inputManager = GetComponent<IInputManager>();

        if(inputManager == null)
        {
            Debug.LogWarning("PcController : IInputManager is required.");
        }
    }

    public void AttachCharacter(ICharacter character)
    {
        if (character != null)
        {
            DetachCharacter();
        }

        this.character = character;

        inputManager.InputEventHandler.Move.started += character.Move;
        inputManager.InputEventHandler.Move.performed += character.Move;
        inputManager.InputEventHandler.Move.canceled += character.Move;
        inputManager.InputEventHandler.Aimming.performed += character.Aimming;
        inputManager.InputEventHandler.Aimming.canceled += character.Aimming;

        inputManager.InputEventHandler.Fire.performed += character.Fire;
        inputManager.InputEventHandler.Jump.started += character.Jump;
        inputManager.InputEventHandler.Sprint.started += character.Sprint;
        inputManager.InputEventHandler.Sprint.canceled += character.Sprint;
        inputManager.InputEventHandler.Interact.started += character.Interact;
    }

    public void DetachCharacter()
    {
        if (character == null) return;

        inputManager.InputEventHandler.Move.performed -= character.Move;
        inputManager.InputEventHandler.Move.canceled -= character.Move;
        inputManager.InputEventHandler.Aimming.performed -= character.Aimming;
        inputManager.InputEventHandler.Aimming.canceled -= character.Aimming;

        inputManager.InputEventHandler.Fire.performed -= character.Fire;
        inputManager.InputEventHandler.Jump.started -= character.Jump;
        inputManager.InputEventHandler.Sprint.started -= character.Sprint;
        inputManager.InputEventHandler.Sprint.canceled -= character.Sprint;
        inputManager.InputEventHandler.Interact.started -= character.Interact;

        character = null;
    }
}
