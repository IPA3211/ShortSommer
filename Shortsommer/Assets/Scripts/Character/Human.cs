using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Human : SommerCharacter
{
    [SerializeField] Transform backWeaponHolder;
    [SerializeField] Transform meleeWeaponHolder;
    [SerializeField] Transform rangeWeaponHolder;

    public override async Task SetWeaponAsync(IWeapon newWeapon)
    {
        await base.SetWeaponAsync(newWeapon);

        UnarmWeapon();
    }

    public void ArmWeapon()
    {
        if(WeaponObject is MeleeWeaponObject)
        {
            WeaponObject.transform.SetParent(meleeWeaponHolder);
        }
        else
        {
            WeaponObject.transform.SetParent(rangeWeaponHolder);
        }

        WeaponObject.transform.localPosition = Vector3.zero;
        WeaponObject.transform.localRotation = Quaternion.identity;
    }

    public void UnarmWeapon()
    {
        WeaponObject.transform.SetParent(backWeaponHolder);
        WeaponObject.transform.localPosition = Vector3.zero;
        WeaponObject.transform.localRotation = Quaternion.identity;
    }
}
