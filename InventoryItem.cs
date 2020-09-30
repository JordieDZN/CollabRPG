using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{

    public InventoryItem(Item i, int stack)
    {
        item = i;
        stack_size = stack;
    }

    private Item item;
    private int stack_size;
    public Item Item { get { return item; } set { item = value; } }
    public int StackSize { get { return stack_size; } set { stack_size = value; } }
}
