using UnityEngine;

public class RangeWeaponObject : WeaponObject
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] BulletObject bullet;
    public override WeaponType WeaponType => WeaponType.Range;
    public override void OnAttackStart()
    {
        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    public override void OnAttackEnd()
    {

    }
}
