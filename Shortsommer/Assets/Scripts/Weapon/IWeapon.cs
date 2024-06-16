using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    WeaponType WeaponType { get; }
    void OnAttackStart();
    void OnAttackEnd();
}
