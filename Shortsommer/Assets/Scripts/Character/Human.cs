using UnityEngine;

public class Human : SommerCharacter
{
    [SerializeField] Transform backWeaponHolder;
    [SerializeField] Transform meleeWeaponHolder;
    [SerializeField] Transform rangeWeaponHolder;

    WeaponObject weapon;

    public void ArmWeapon()
    {
        if(weapon is MeleeWeaponObject)
        {
            weapon.transform.SetParent(meleeWeaponHolder);
        }
        else
        {
            weapon.transform.SetParent(rangeWeaponHolder);
        }

        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
    }

    public void UnarmWeapon()
    {
        weapon.transform.SetParent(meleeWeaponHolder);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
    }
}
