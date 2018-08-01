using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour {

    public float speed;

    public KeyCode rightkey, upkey, downkey, leftkey;

    public GameObject inventoryhub;
    public GameObject armorinventoryhub;
    public Animator anim;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        if(Game_manager.player == null)
        {
            Game_manager.player = gameObject;
        } else
        {
            if(Game_manager.player != gameObject)
                {
                Destroy(gameObject);
                return;
            }
        }
    }
    private bool created;
	// Update is called once per frame
	void FixedUpdate () {
            
        if (Input.GetKey(rightkey))
            {           
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("Walkingright", true);
        }

        if (Input.GetKey(leftkey))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            anim.SetBool("Walkingleft", true);
        }

        if (Input.GetKey(upkey))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
            anim.SetBool("Walkup", true);
        }

        if (Input.GetKey(downkey))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            anim.SetBool("Walkingdown", true);
        }

        if(shouldianim)
        {
            anim.SetBool("Walkingright", false);
            anim.SetBool("Walkingleft", false);
            anim.SetBool("Walkup", false);
            anim.SetBool("Walkingdown", false);
            shouldianim = false;
        }

        if (Input.GetKeyUp(rightkey))
        {
            anim.SetBool("Walkingright", false);
            shouldianim = true;
        }

        if (Input.GetKeyUp(leftkey))
        {
            anim.SetBool("Walkingleft", false);
            shouldianim = true;
        }

        if (Input.GetKeyUp(upkey))
        {
            anim.SetBool("Walkup", false);
            shouldianim = true;
        }

        if (Input.GetKeyUp(downkey))
        {          
            anim.SetBool("Walkingdown", false);
            shouldianim = true;
        }



        if(anim.GetBool("Walkingdown") == true)
        {
            if(Input.GetKey(downkey))
            {

            } else
            {
                anim.SetBool("Walkingdown", false);
            }
        }


        if (anim.GetBool("Walkup") == true)
        { 
            if (Input.GetKey(upkey))
            {

            }
            else
            {
                anim.SetBool("Walkup", false);
            }
        }



        if (anim.GetBool("Walkingright") == true)
        {
            if (Input.GetKey(rightkey))
            {

            }
            else
            {
                anim.SetBool("Walkingright", false);
            }
        }



        if (anim.GetBool("Walkingleft") == true)
        {
            if (Input.GetKey(leftkey))
            {

            }
            else
            {
                anim.SetBool("Walkingleft", false);
            }
        }
    }
    public bool shouldianim;
}
