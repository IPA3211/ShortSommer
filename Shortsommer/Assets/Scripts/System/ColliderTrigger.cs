using UnityEngine;
using UnityEngine.Events;

public class ColliderTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent<Collider> onTriggerEnter;
    [SerializeField] UnityEvent<Collider> onTriggerStay;
    [SerializeField] UnityEvent<Collider> onTriggerExit;

    public UnityEvent<Collider> OnTriggerEnterEvent => onTriggerEnter;
    public UnityEvent<Collider> OnTriggerStayEvent => onTriggerStay;
    public UnityEvent<Collider> OnTriggerExitEvent => onTriggerExit;

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
