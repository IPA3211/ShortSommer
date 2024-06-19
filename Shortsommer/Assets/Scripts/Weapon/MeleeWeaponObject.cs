using UnityEngine;

public class MeleeWeaponObject : WeaponObject
{
    bool isAttaking = false;
    public override WeaponType WeaponType => WeaponType.Melee;

    public void Start()
    {
        var ct = GetComponent<ColliderTrigger>();
        ct.OnTriggerEnterEvent.AddListener(e => OnHit(e));
    }

    public override void OnAttackStart()
    {
        isAttaking = true;
    }

    public override void OnAttackEnd()
    {
        isAttaking = false;
    }

    public virtual void OnHit(Collider other)
    {
        if (isAttaking)
        {
            Debug.Log(other);
        }
    }
}
