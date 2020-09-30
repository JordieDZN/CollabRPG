using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{

    /*
    * Connor wrote the movement code
    * Includes Animation and Sprite Flipping.
    * 
    * Jordie wrote the inventory code.
    */
    private Vector2 movement;
    private Rigidbody2D rigidbody;
    public float speed;
    private Animator animator;

    public static Player instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioManager.instance.Play("Game_Loop");
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GameManager.instance.spawnCollectable(Items.instance.wood, 50, new Vector2(60f, -105f));
    }

    void Update()
    {

        if(!Inventory.instance.isOpen)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        } else
        {
            movement.x = 0f;
            movement.y = 0f;
        }

        if(movement != Vector2.zero)
        {

            animator.SetBool("moving", true);
            AudioManager.instance.Play("Footsteps", false);

        } else
        {

            animator.SetBool("moving", false);
            AudioManager.instance.Stop("Footsteps");

        }

        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown((KeyCode)i + 48))
            {
                if (i == 0) Inventory.instance.setActive(9);
                else Inventory.instance.setActive(i - 1);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (Inventory.instance.active == 9) Inventory.instance.setActive(0);
            else Inventory.instance.setActive(Inventory.instance.active + 1);
        } else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (Inventory.instance.active == 0) Inventory.instance.setActive(9);
            else Inventory.instance.setActive(Inventory.instance.active - 1);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Inventory.instance.toggleView();
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            foreach(ItemCollectable coll in GameManager.instance.currentCollectables.ToList())
            {
                Inventory.instance.addItem(coll);
                Destroy(coll.gameObject);
            }
            GameManager.instance.currentCollectables.Clear();
        }
    }

    private void FixedUpdate()
    {
        if(movement.x < 0f)
        {
            Vector2 scale = this.transform.localScale;
            scale.x = -1;
            this.transform.localScale = scale;
        } else if(movement.x > 0f)
        {
            Vector2 scale = this.transform.localScale;
            scale.x = 1;
            this.transform.localScale = scale;
        }
        rigidbody.MovePosition(rigidbody.position + movement * speed * Time.fixedDeltaTime);
    }
}
