using UnityEngine;

public class SommerDroppedObject : SommerObject, IInteractee
{
    public bool IsCanInteract(IInteracter interacter)
    {
        switch (interacter)
        {
            case SommerCharacter:
                return true;
            default: return false;
        }
    }

    public void OnHighlight(IInteracter interacter)
    {
        if (IsCanInteract(interacter))
        {

        }
    }

    public void OnInteract(IInteracter interacter)
    {
        if(IsCanInteract(interacter))
        {
            Destroy(gameObject);
        }
    }
}
