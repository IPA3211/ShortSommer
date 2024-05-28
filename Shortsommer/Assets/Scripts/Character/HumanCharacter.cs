using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]
public class HumanCharacter : MonoBehaviour, ICharacter
{
    [SerializeField] Transform slopeSensorPos;

    Rigidbody rb;

    bool isOnGround = false;
    bool isSprint = false;

    float accSpeed = 1f;
    float walkSpeed = 7f;
    float sprintSpeed = 12f;
    float runSpeed = 10f;
    float jumpPower = 200f;

    Vector2 moveDir = Vector2.zero;
    Vector3 aimmingDir = Vector3.zero;
    Vector3 slopeNormal = Vector3.up;

    IController controller = null;
    public bool IsOnGround => isOnGround;
    public bool IsSprint => isSprint;
    public IController Controller => controller;
    
    public float MoveSpeed // 최종 이동속도
    {
        get
        {
            if (aimmingDir == Vector3.zero)
            {
                if (isSprint)
                {
                    return sprintSpeed;
                }
                else
                {
                    return runSpeed;
                }
            }
            else
            {
                return walkSpeed;
            }
        } 
    }

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
    public void Aimming(Vector3 target)
    {
        aimmingDir = target;
        Debug.Log(target);
    }
    public void Sprint(bool toggle)
    {
        isSprint = toggle;
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
        if (moveDir != Vector2.zero && isOnGround)
        {
            var direction3D = new Vector3(moveDir.x, 0, moveDir.y);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction3D), 0.3f);

            var projectVector = Vector3.ProjectOnPlane(transform.forward, slopeNormal);
            projectVector.Normalize();

            if (Vector2.Angle(moveDir, new Vector2(transform.forward.x, transform.forward.z)) < 10)
            {
                if (rb.velocity.magnitude < MoveSpeed)
                {
                    rb.AddForce(projectVector * accSpeed, ForceMode.VelocityChange);
                }
            }
        }
    }

    void GetSlopeNormal()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        var ray = new Ray(slopeSensorPos.position, Vector3.down);

        if(Physics.Raycast(ray, out var hit, 2f, layerMask))
        {
            slopeNormal = hit.normal;
        }
        else
        {
            slopeNormal = Vector3.up;
        }
    }

    void FixedUpdate()
    {
        GetSlopeNormal();
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
