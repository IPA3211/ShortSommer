using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour, IController
{
    public HumanCharacter defaultAttach;
    InputSystem myInputSystem;
    ICharacter character;

    public ICharacter Character => character;

    public void AttachCharacter(ICharacter character)
    {
        this.character = character;
    }

    public void DetachCharacter()
    {
        character = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myInputSystem.Player.Move.IsInProgress())
        {
            character.Move(myInputSystem.Player.Move.ReadValue<Vector2>());
        }
    }

    void Start()
    {
        myInputSystem = new InputSystem();
        myInputSystem.Player.Move.Enable();
        AttachCharacter(defaultAttach);
    }
}
