using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SommerObject : MonoBehaviour
{
    List<IInteractee> interactees = new();

    public void AddInteractee(IInteractee interactee)
    {
        interactees.Add(interactee);
    }

    public void OnHighlighted(IInteracter other)
    {

    }

    public void OnInteracted(IInteracter other)
    {
        foreach(var interactee in interactees)
        {
            if(interactee.IsCanInteract(other))
            {
                interactee.OnInteract(other);
            }
        }
    }
}
