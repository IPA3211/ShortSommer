using System;
using UnityEngine;

[Serializable]
public class BaseItem : Def, IDescriptable, IStackable
{
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] string icon;
    [SerializeField] int maxStack;
    [SerializeField] string prefabPath;
    
    public string Name => name;
    public string Description => description;
    public string Icon => icon;
    public int MaxStack => maxStack;
    public string PrefabPath => prefabPath;
}