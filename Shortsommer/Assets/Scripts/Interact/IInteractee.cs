public interface IInteractee
{
    bool IsCanInteract(IInteracter interacter);
    void OnHighlight(IInteracter interacter);
    void OnInteract(IInteracter interacter);
}
