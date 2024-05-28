using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SommerCharacter : MonoBehaviour, IControllee
{
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
    IController controller = null;

    Vector3 MoveDir3D => new Vector3(moveDir.x, 0, moveDir.y);
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
        controller.AttachControllee(this);
    }

    public void DetachController()
    {
        if(controller == null) return;

        moveDir = Vector2.zero;
        controller.DetachControllee();
        controller = null;
    }
    public virtual void Move(Vector2 direction)
    {
        moveDir = direction;
        if (moveDir != Vector2.zero && isOnGround) // 땅에서 움직이는 중
        {
            if (aimmingDir == Vector3.zero) // 조준 안함
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(MoveDir3D), 0.3f);
                if (Vector2.Angle(moveDir, new Vector2(transform.forward.x, transform.forward.z)) < 10)
                {
                    AddForceWithProject(transform.forward, accSpeed, MoveSpeed);
                }
            }
            else // 조준중
            {
                AddForceWithProject(MoveDir3D, accSpeed, MoveSpeed);
            }
        }
    }
    public virtual void Aimming(Vector3 target)
    {
        aimmingDir = target;
        
        var rotateTo = aimmingDir - transform.position;
        rotateTo.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateTo), 0.3f);
    }
    public virtual void Sprint(bool toggle)
    {
        isSprint = toggle;
    }
    public virtual void Jump(bool o)
    {
        if (isOnGround)
        {
            rb.AddForce(Vector3.up * jumpPower);
        }
    }
    public virtual void Interact(bool o)
    {
        Debug.Log("Interact");
    }

    public virtual void Fire(bool o)
    {
        Debug.Log("Fire");
    }

    void AddForceWithProject(Vector3 dir, float pow, float cap)
    {
        var slopeNormal = GetSlopeNormal();
        if (rb.velocity.magnitude < cap)
        {
            var projectVector = Vector3.ProjectOnPlane(dir, slopeNormal);
            projectVector.Normalize();
            rb.AddForce(projectVector * pow, ForceMode.VelocityChange);
        }
    }

    Vector3 GetSlopeNormal()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        var ray = new Ray(transform.position + MoveDir3D * 0.2f, Vector3.down);

        if(Physics.Raycast(ray, out var hit, 2f, layerMask))
        {
            return hit.normal;
        }
        else
        {
            return Vector3.up;
        }
    }

    protected virtual void Start()
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
