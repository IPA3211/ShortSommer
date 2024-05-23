using UnityEngine;

public interface ICharacter
{
    IController Controller { get; }
    public void AttachController(IController controller);
    public void DetachController();
    public void Move(Vector2 direction);
    void Jump(bool o);
    void Sprint(bool toggle);
    void Interact(bool o);
    void Fire(bool o);
    void Aimming(Vector3 target);
}
