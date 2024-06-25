using System;
using UnityEngine;

[Serializable]
public class TemplateItem : IDescriptable, IStackable
{
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] string icon;
    [SerializeField] int maxStack;

    public string Name => name;
    public string Description => description;
    public string Icon => icon;
    public int MaxStack => maxStack;

    public TemplateItem(string name, string description, string icon)
    {
        this.name = name;
        this.description = description;
        this.icon = icon;
    }
}