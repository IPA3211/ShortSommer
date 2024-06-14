using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SommerCharacter : SommerObject, IControllee, IInteracter
{
    bool isOnGround = false;
    bool isSprint = false;

    readonly float accSpeed = 1f;
    readonly float maxSpeed = 10;
    readonly float walk = 0.5f;
    readonly float sprint = 1f;
    readonly float run = 0.75f;
    readonly float jumpPower = 200f;

    Vector2 moveDir = Vector2.zero;
    Vector3 aimmingDir = Vector3.zero;
    Vector3 fireDir = Vector3.zero;
    IController controller = null;

    Rigidbody rb = null;

    public Vector3 AimmingDir3D => aimmingDir;
    public Vector3 MoveDir3D => new Vector3(moveDir.x, 0, moveDir.y);
    public Vector3 FireDir => fireDir;
    public Vector3 Velocity => rb.velocity;
    public float MaxSpeed => maxSpeed;
    public bool IsOnGround => isOnGround;
    public bool IsSprint => isSprint;
    public IController Controller => controller;

    public float MoveMultiplier // 최종 이동속도
    {
        get
        {
            if (aimmingDir == Vector3.zero)
            {
                if (isSprint)
                {
                    return sprint;
                }
                else
                {
                    return run;
                }
            }
            else
            {
                return walk;
            }
        }
    }

    public void AttachController(IController controller)
    {
        if (this.controller == controller) return;

        DetachController();
        this.controller = controller;
        controller.AttachControllee(this);
    }

    public void DetachController()
    {
        if (controller == null) return;

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
                if (Vector2.Angle(moveDir, new Vector2(transform.forward.x, transform.forward.z)) < 170)
                {
                    AddForceWithProject(transform.forward, accSpeed, MoveMultiplier * maxSpeed);
                }
            }
            else // 조준중
            {
                AddForceWithProject(MoveDir3D, accSpeed, MoveMultiplier * maxSpeed);
            }
        }
    }
    public virtual void Aimming(Vector3 target)
    {
        aimmingDir = target;

        if(aimmingDir != Vector3.zero)
        {
            var rotateTo = aimmingDir - transform.position;
            rotateTo.y = 0;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotateTo), 0.3f);
        }
    }
    public virtual void Fire(Vector3 target)
    {
        fireDir = target;
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
        int layerMask = 1 << LayerMask.NameToLayer("Default");
        var ray = new Ray(transform.position + transform.forward * 0.2f, transform.forward);
        if (Physics.Raycast(ray, out var hit, 2f, layerMask))
        {
            if (hit.collider.TryGetComponent<IInteractee>(out var interactee))
            {
                interactee.OnInteract(this);
            }
        }
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
        
        if (Physics.Raycast(ray, out var hit, 2f, layerMask))
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
