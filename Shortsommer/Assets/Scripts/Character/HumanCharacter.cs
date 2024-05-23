using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCharacter : MonoBehaviour, ICharacter
{
    Rigidbody rb;

    float accSpeed = 1f;
    float walkSpeed = 7f;
    float sprintSpeed = 12f;
    float maxSpeed = 10f;

    Vector2 moveDir = Vector2.zero;

    Controller controller = null;
    public Controller Controller => controller;

    public void AttachController(Controller controller)
    {
        if(this.controller == controller) return;

        DetachController();
        this.controller = controller;

        controller.Move.performed += Move;
        controller.Move.canceled += Move;
        controller.Jump.started += Jump;
    }

    public void DetachController()
    {
        if(controller == null) return;

        controller.Move.performed -= Move;
        controller.Move.canceled -= Move;
        controller.Jump.started -= Jump;

        moveDir = Vector2.zero;

        controller = null;
    }

    public void Move(object direction)
    {
        Move((Vector2) direction);
    }
    public void Move(Vector2 direction)
    {
        moveDir = direction;
    }

    public void Jump(object _)
    {
        Debug.Log("aaa");
        DetachController();
    }

    public void Sprint(bool toggle)
    {

    }
    public void Aimming(Vector3 target)
    {

    }

    void Move()
    {
        if (moveDir != Vector2.zero)
        {
            var direction3D = new Vector3(moveDir.x, 0, moveDir.y);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction3D), 0.4f);

            if (Vector2.Angle(moveDir, new Vector2(transform.forward.x, transform.forward.z)) < 10)
            {
                if (rb.velocity.magnitude < maxSpeed)
                {
                    rb.AddForce(transform.forward * accSpeed, ForceMode.VelocityChange);
                }
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
