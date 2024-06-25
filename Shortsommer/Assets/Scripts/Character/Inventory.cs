using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Inventory
{
    int inventorySize = 0;
    int weaponIndex;
    List<(int itemIndex, int num)> inventory = new();

    public Inventory(int size)
    {
        inventorySize = size;
        inventory.Capacity = size;
    }
}
