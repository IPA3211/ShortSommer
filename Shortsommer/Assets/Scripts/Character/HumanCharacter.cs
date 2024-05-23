using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCharacter : MonoBehaviour, ICharacter
{
    Rigidbody rb;

    float rotSpeed = 30f;
    float moveSpeed = 1f;
    float maxSpeed = 10f;

    IController controller = null;
    public IController Controller => controller;

    public void AttachController(IController controller)
    {
        if(this.controller == controller) return;

        DetachController();
        this.controller = controller;
        controller.AttachCharacter(this);
    }

    public void DetachController()
    { 
        controller?.DetachCharacter();
        controller = null;
    }

    public void Move(Vector2 direction)
    {
        var direction3D = new Vector3(direction.x, 0, direction.y);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction3D), 0.4f);
        
        if(Vector2.Angle(direction, new Vector2(transform.forward.x, transform.forward.z)) < 10)
        {
            if(rb.velocity.magnitude < maxSpeed)
            {
                rb.AddForce(transform.forward * moveSpeed, ForceMode.VelocityChange);
            }
        }
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
