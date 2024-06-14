using UnityEngine;

public interface IControllee
{
    IController Controller { get; }
    void AttachController(IController controller);
    void DetachController();
    void Move(Vector2 direction);
    void Aimming(Vector3 target);
    void Fire(Vector3 target);
    void Jump(bool o);
    void Sprint(bool toggle);
    void Interact(bool o);
}
