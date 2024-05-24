using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HumanCharacter : MonoBehaviour, ICharacter
{
    [SerializeField] Transform slopeSensorPos;

    Rigidbody rb;

    bool isOnGround = false;

    float accSpeed = 1f;
    float walkSpeed = 7f;
    float sprintSpeed = 12f;
    float maxSpeed = 10f;
    float jumpPower = 200f;

    Vector2 moveDir = Vector2.zero;
    Vector3 slopeNormal = Vector3.up;

    IController controller = null;
    public bool IsGround => throw new System.NotImplementedException();
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
        if(controller == null) return;

        moveDir = Vector2.zero;
        controller.DetachCharacter();
        controller = null;
    }
    public void Move(Vector2 direction)
    {
        moveDir = direction;
    }

    public void Sprint(bool toggle)
    {
        Debug.Log("Sprint");
    }
    public void Aimming(Vector3 target)
    {
        Debug.Log("Aimming"); 
    }
    public void Jump(bool o)
    {
        if (isOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
    }

    public void Interact(bool o)
    {
        Debug.Log("Interact");
    }

    public void Fire(bool o)
    {
        Debug.Log("Fire");
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

    void OnTriggerStay(Collider other)
    {
        isOnGround = true;
    }
    void OnTriggerExit(Collider other)
    {
        isOnGround = false;
    }

}
