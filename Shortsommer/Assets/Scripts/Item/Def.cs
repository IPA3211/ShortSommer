using System;
using UnityEngine;

[Serializable]
public class Def
{
    [SerializeField] string defId;

    public string DefId => defId;
}
