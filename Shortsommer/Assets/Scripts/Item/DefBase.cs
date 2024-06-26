using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class DefBase
{
    [SerializeField] string defClass;
    [SerializeField] string defId;

    public string DefClass => defClass;
    public string DefId => defId;
}
