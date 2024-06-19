using UnityEngine;

public class RangeWeaponObject : WeaponObject
{
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] BulletObject bullet;
    public override WeaponType WeaponType => WeaponType.Range;
    public override void OnAttackStart()
    {
        Destroy(Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation), 3);
    }

    public override void OnAttackEnd()
    {

    }
}
