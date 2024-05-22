public interface IController
{
    public ICharacter Character { get; }
    public void AttachCharacter(ICharacter character);
    public void DetachCharacter();
}
