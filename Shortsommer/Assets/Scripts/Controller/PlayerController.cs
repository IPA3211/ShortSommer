using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class PlayerController : MonoBehaviour, IController
{
    public HumanCharacter defaultAttach;
    InputSystem playerInput;
    ICharacter character;

    public ICharacter Character => character;

    public void AttachCharacter(ICharacter character)
    {
        if(this.character == character) return;

        DetachCharacter();
        this.character = character;
        character.AttachController(this);
    }

    public void DetachCharacter()
    {
        character?.DetachController();
        character = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInput.Player.Move.IsInProgress())
        {
            character.Move(playerInput.Player.Move.ReadValue<Vector2>());
        }
    }

    void Start()
    {
        playerInput = new InputSystem();
        playerInput.Player.Move.Enable();
    }
}
