using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ItemSystem
{
    Dictionary<int, IDescriptable> index2ItemDic = new Dictionary<int, IDescriptable>();
    Dictionary<IDescriptable, int> item2IndexDic = new Dictionary<IDescriptable, int>();

    public ItemSystem()
    {

    }
}