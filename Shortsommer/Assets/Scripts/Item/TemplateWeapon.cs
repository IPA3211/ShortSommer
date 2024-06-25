using System;
using UnityEngine;

[Serializable]
public class TemplateWeapon : IEquipment
{
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] string icon;
    [SerializeField] string prefabPath;

    public string Name => name;
    public string Description => description;
    public string Icon => icon;
    public string PrefabPath => prefabPath;

    public TemplateWeapon(string name, string description, string icon, string prefabPath)
    {
        this.name = name;
        this.description = description;
        this.icon = icon;
        this.prefabPath = prefabPath;
    }
}