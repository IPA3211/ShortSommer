using System;
using UnityEngine;

[Serializable]
public class ItemWeapon : IEquipment
{
    [SerializeField] WeaponType type;
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] string icon;

    public string Name => Name;
    public string Description => description;
    public string Icon => icon;

}