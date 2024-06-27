using System;
using UnityEngine;

[Serializable]
public class BaseRangeWeapon : Def, IDescriptable, IWeapon
{
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] string icon;
    [SerializeField] string prefabPath;
    float attackSpeed = 1f;
    string bulletPrefab = "";
    
    public float AttackSpeed => attackSpeed;
    public string Name => name;
    public string Description => description;
    public string Icon => icon;
    public string PrefabPath => prefabPath;
    public string BulletPrefab => bulletPrefab;
}