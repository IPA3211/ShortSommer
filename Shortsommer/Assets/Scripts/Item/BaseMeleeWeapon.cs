using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseMeleeWeapon : Def, IDescriptable, IWeapon
{
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] string icon;
    [SerializeField] string prefabPath;
    [SerializeField] float attackSpeed = 1f;

    public float AttackSpeed => attackSpeed;
    public string Name => name;
    public string Description => description;
    public string Icon => icon;
    public string PrefabPath => prefabPath;

    public void OnHit(SommerCharacter other)
    {

    }
}