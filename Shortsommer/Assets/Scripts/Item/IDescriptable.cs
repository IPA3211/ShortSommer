using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface IDescriptable
{
    string Name { get; }
    string Description { get; }
    string Icon { get; }
}
