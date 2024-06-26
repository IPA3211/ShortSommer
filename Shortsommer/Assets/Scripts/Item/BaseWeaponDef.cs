using System;
using UnityEngine;

[Serializable]
public class BaseWeaponDef : BaseItemDef
{
    [SerializeField] string prefabPath;

    public string PrefabPath => prefabPath;  
}