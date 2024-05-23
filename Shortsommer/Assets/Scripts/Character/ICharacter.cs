using UnityEngine;

public interface ICharacter
{
    IController Controller { get; }
    public void AttachController(IController controller);
    public void DetachController();
    public void Move(Vector2 direction);
}