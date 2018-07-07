using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Enemie_Display : MonoBehaviour {

    public Enemie enemie;
    public GameObject aimobject;

    public bool flip;
    public int health = 1;

    public bool battleenemy;
    public Slider Healthslider;

    public static int id;

	IEnumerator waitsmall()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForSeconds(id / 10);
        health = enemie.Health;
        if (Healthslider != null)
        {
            Healthslider.maxValue = enemie.Health;
            Healthslider.value = enemie.Health;
        }

        GameObject kill;
        foreach (string str in Game_manager.killus)
        {
            kill = GameObject.Find(str);
            if (kill != null)
            {
                Destroy(kill);
            }
        }
        if(battleenemy)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enemie.look;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(enemie.size.x, enemie.size.y, 1);
        } else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = enemie.flocksprite;
        }

    }


	void Start () {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        if (flip)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        id = 0;
        health = +1;
        StartCoroutine(waitsmall());
        
    }

    void OnMouseOver()
    {
        if(TMPro.Examples.Attack_Button.pressed == true)
        {
            TMPro.Examples.Player_Attacks.hovering = true;
            TMPro.Examples.Player_Attacks.whatishoveringover = gameObject;
            aimobject.SetActive(true);
            Cursor.visible = false;        
        }

    }
    public GameObject dieeffect;

    private void FixedUpdate()
    {
        if (Healthslider != null)
        {
            Healthslider.value = health;
        }
        if(health <= 0)
        {
            TMPro.Examples.State_Machine.deadenemys++;
            Instantiate(dieeffect, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
        if (TMPro.Examples.Attack_Button.pressed == false && aimobject != null)
        {
            aimobject.SetActive(false);
            Cursor.visible = true;
        }
    }

    void OnMouseExit()
    {
        if(aimobject != null)
        {
            aimobject.SetActive(false);
        }
        Cursor.visible = true;
        TMPro.Examples.Player_Attacks.hovering = false;
    }
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Game_manager.WhatEnemyAreYouFacing = enemie.Name;
            Game_manager.enemytodestroyid = gameObject.name;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<BoxCollider2D>().enabled = false;
            player.SetActive(false);
            SceneManager.LoadScene(3);          
        }

    }

    private int dmg;
    public void Attack()
    {
        int randomattack = Random.Range(1, 4);
        TMPro.Examples.State_Machine.enemyattackedbuy = enemie.Name;
        if (randomattack == 1)
        {
            dmg = enemie.attack1_dmg;
            TMPro.Examples.State_Machine.attackbyenemy = enemie.Attack1;
            TMPro.Examples.State_Machine.dmgbeingdonebyenemy = enemie.attack1_dmg;
        }
        if (randomattack == 2)
        {
            dmg = enemie.attack2_dmg;
            TMPro.Examples.State_Machine.attackbyenemy = enemie.Attack2;
            TMPro.Examples.State_Machine.dmgbeingdonebyenemy = enemie.attack2_dmg;
        }
        if (randomattack == 3)
        {
            dmg = enemie.attack3_dmg;
            TMPro.Examples.State_Machine.attackbyenemy = enemie.Attack3;
            TMPro.Examples.State_Machine.dmgbeingdonebyenemy = enemie.attack3_dmg;
        }
        TMPro.Examples.Player_Attacks.health -= dmg;
    }
}
 