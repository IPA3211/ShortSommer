using UnityEngine;

public interface ICharacter
{
    Controller Controller { get; }
    public void AttachController(Controller controller);
    public void DetachController();
    public void Move(Vector2 direction);
    void Jump(object o);
    void Sprint(bool toggle);
}
