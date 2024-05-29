using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent<Collider> onTriggerEnter;
    [SerializeField] UnityEvent<Collider> onTriggerStay;
    [SerializeField] UnityEvent<Collider> onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter?.Invoke(other);
    }
    private void OnTriggerStay(Collider other)
    {
        onTriggerStay?.Invoke(other);
    }
    private void OnTriggerExit(Collider other)
    {
        onTriggerExit?.Invoke(other);
    }
}
