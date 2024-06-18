using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponObject : MonoBehaviour, IWeapon
{
    public virtual WeaponType WeaponType => WeaponType.None;

    public virtual void OnAttackStart()
    {

    }

    public virtual void OnAttackEnd()
    {

    }
}
