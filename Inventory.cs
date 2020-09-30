using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image[] slot_items;
    public int inventory_size;
    public List<InventoryItem> inventory = new List<InventoryItem>();
    public int active = 0;
    public int highlighted = -1;
    public Sprite slot;
    public Sprite slot_active;
    public Sprite slot_highlighted;
    public TextMeshProUGUI text;
    public bool isOpen = false;
    [SerializeField] private GameObject inventory_view;

    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void Start()
    {
        for (int i = 0; i < inventory_size; i++)
        {
            inventory.Add(null);

        }

        inventory[6] = new InventoryItem(Items.instance.stone_sword, 1);
    }

    public void Update()
    {

        for (int i = 0; i < slot_items.Length; i++)
        {
            if (slot_items[i] == null) 
                return;

            if (active == i)
                slot_items[i].sprite = slot_active;
            else if (highlighted == i)
                slot_items[i].sprite = slot_highlighted;
            else
                slot_items[i].sprite = slot;

            if (inventory[i] == null)
            {
                Image sprite = slot_items[i].gameObject.transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI tm = slot_items[i].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                tm.text = "";
                sprite.sprite = null;
                sprite.color = new Color(0, 0, 0, 0.3f);
            }
            else
            {
                Image sprite = slot_items[i].gameObject.transform.GetChild(0).GetComponent<Image>();
                TextMeshProUGUI tm = slot_items[i].gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                if (inventory[i].StackSize > 1) tm.text = $"{inventory[i].StackSize}";
                else tm.text = "";
                sprite.sprite = inventory[i].Item.Sprite;
                sprite.color = new Color(1, 1, 1, 1f);
            }



        }

    }

    public void toggleView()
    {
        isOpen = !isOpen;
        inventory_view.SetActive(!inventory_view.activeSelf);
        highlighted = -1;
    }

    public void selectSlot(int slot)
    {
        if (isOpen)
        {

            if (highlighted == slot)
            {
                highlighted = -1;
                AudioManager.instance.Play("Item_Switch");

            }
            else if (highlighted == -1)
            {
                highlighted = slot;
                AudioManager.instance.Play("Slot_Highlight");
            }
            else
            {

                InventoryItem selected = inventory[highlighted];
                InventoryItem updated = inventory[slot];
                if (selected != null && updated != null)
                {
                    if (selected.Item == updated.Item && updated.Item.Stackable)
                    {
                        selected = new InventoryItem(selected.Item, selected.StackSize + updated.StackSize);
                        updated = null;
                    }
                }
                inventory[highlighted] = updated;
                inventory[slot] = selected;
                highlighted = -1;
                AudioManager.instance.Play("Item_Switch");

            }
        }
        else
        {
            setActive(slot);
        }

    }

    public void setActive(int slot)
    {
        if (slot < 0 || slot > 9) return;
        active = slot;
        AudioManager.instance.Play("Item_Switch");
    }

    public void addItem(ItemCollectable item)
    {
        int i = 0;
        foreach (InventoryItem invItem in inventory.ToList())
        {
            if (invItem != null && invItem.Item != null)
            {
                if (invItem.Item == item.item && i == 0)
                {
                    invItem.StackSize += item.stack;
                    i++;
                }
            }
        }

        if (i == 0)
        {
            for(int j = 0; j < inventory.Count; j++)
            {
                if (inventory[j] == null && i == 0)
                {
                    inventory[j] = new InventoryItem(item.item, item.stack);
                    i++;
                }
            }
        }
    }

}
