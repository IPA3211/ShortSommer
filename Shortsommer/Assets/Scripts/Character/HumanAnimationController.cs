using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Human))]
[RequireComponent(typeof(Animator))]
public class HumanAnimationController : MonoBehaviour, ICharacterAniCallback
{
    Human human;
    Animator animator;
    public void AnimAttackStart()
    {
        human.WeaponObject?.OnAttackStart();
    }
    public void AnimAttackEnd()
    {
        human.WeaponObject?.OnAttackEnd();
    }
    public void AnimEquipWeaponStart()
    {
        human.ArmWeapon();
    }
    public void AnimEquipWeaponEnd()
    {
        human.UnarmWeapon();
    }

    void Start()
    {
        human = GetComponent<Human>();
        animator = GetComponent<Animator>();
    }
    protected void FixedUpdate()
    {
        var temp2D = new Vector2(transform.forward.x, transform.forward.z);

        if (human.AimmingDir3D != Vector3.zero)
        {
            var moveDir = Quaternion.AngleAxis(Vector2.SignedAngle(temp2D, new Vector2(human.Velocity.x, human.Velocity.z)), Vector3.up) * new Vector3(Mathf.InverseLerp(0, human.MaxSpeed, human.Velocity.magnitude), 0, 0);
            animator.SetFloat("MoveX", moveDir.x);
            animator.SetFloat("MoveY", moveDir.z);

            animator.SetBool("IsAimming", true);
            animator.SetBool("IsAttacking", human.FireDir != Vector3.zero);
        }
        else
        {
            animator.SetFloat("MoveX", Mathf.InverseLerp(0, human.MaxSpeed, human.Velocity.magnitude));
            animator.SetFloat("MoveY", 0);

            animator.SetBool("IsAimming", false);
            animator.SetBool("IsAttacking", false);
        }

        animator.SetInteger("WeaponType", human.WeaponObject != null ? (int)human.WeaponObject.WeaponType : 0);
    }

}
