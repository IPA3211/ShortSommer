public interface IInteractee
{
    bool IsCanInteract(IInteracter interacter);
    void OnInteract(IInteracter interacter);
}
