
public interface IController
{
    ICharacter Character { get; }
    void AttachCharacter(ICharacter character);
    void DetachCharacter();
}
