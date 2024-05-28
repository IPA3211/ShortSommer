
public interface IController
{
    IControllee Controllee { get; }
    void AttachControllee(IControllee character);
    void DetachControllee();
}
