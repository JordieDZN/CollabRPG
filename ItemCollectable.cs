using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class ItemCollectable : MonoBehaviour
{

    public Item item;
    public int stack;
    private Vector3 location;
    private SpriteRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(item != null)
        {
            if(!renderer.enabled) renderer.enabled = true;
            if(renderer.sprite != item.Sprite) renderer.sprite = item.Sprite;
        } else
        {
            renderer.enabled = false;
        }
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") != true) return;
        GameManager.instance.currentCollectables.Add(this);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") != true) return;
        int i = 0;
        foreach(ItemCollectable coll in GameManager.instance.currentCollectables.ToList())
        {
            if (coll.item == item && coll.stack == stack && i == 0)
            {
                GameManager.instance.currentCollectables.Remove(coll);
                i++;
            }
        };
    }

}
