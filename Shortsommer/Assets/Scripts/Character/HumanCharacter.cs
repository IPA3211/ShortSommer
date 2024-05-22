using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCharacter : MonoBehaviour, ICharacter
{
    Rigidbody rb;

    float rotSpeed = 100f;
    float moveSpeed = 500f;

    public void AttachController(IController controller)
    {
        throw new System.NotImplementedException();
    }

    public void DetachController()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector2 direction)
    {
        var direction3D = new Vector3(direction.x, 0, direction.y);
        transform.forward = Vector3.Lerp(transform.forward, direction3D, rotSpeed * Time.deltaTime);
        rb.AddForce(transform.forward * moveSpeed * Time.deltaTime);
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
