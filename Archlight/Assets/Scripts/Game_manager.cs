using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Game_manager : MonoBehaviour {

    public static string WhatEnemyAreYouFacing;
    public static GameObject player;
    public static GameObject enemytodestroyafterwin;
    public static GameObject realcamera;
    public GameObject enemydeadeffect;
    private static bool created = false;
    public static GameObject me;
    public static List<string> killus = new List<string>();


    public static string Playername = "KIMMY";

    // Use this for initialization
    void Start () {
        me = gameObject;
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;          
        } else
        {
            Destroy(gameObject);
        }
    }
    public static string enemytodestroyid;
    private bool createda;
    IEnumerator FindObject()
    {
        enemytodestroyafterwin = GameObject.Find(enemytodestroyid);
        if (enemytodestroyafterwin == null)
        {
            yield return new WaitForFixedUpdate();

            StartCoroutine(FindObject());
        }
        if (enemytodestroyafterwin != null)
        {
            if (!createda)
            {
                Instantiate(enemydeadeffect, enemytodestroyafterwin.transform.position, Quaternion.identity);
                createda = true;
                killus.Add(enemytodestroyafterwin.name);
            }            
            Destroy(enemytodestroyafterwin);
            player.SetActive(true);
            yield return new WaitForSeconds(1f);       
            player.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public static Vector3 velocity;
    public void windo()
    {       
        createda = false;
        velocity = new Vector3(PlayerPrefs.GetFloat("playerx"), PlayerPrefs.GetFloat("playery"), PlayerPrefs.GetFloat("playerz"));
        player.transform.position = velocity;
        
             
        if(enemytodestroyafterwin == null)
        {
            StartCoroutine(FindObject());
        }           
    }
    // Update is called once per frame
    void FixedUpdate () {
        float playerposx = player.transform.position.x ;
        float playerposy = player.transform.position.y;
        float playerposz = player.transform.position.z;
        PlayerPrefs.SetFloat("playerx", playerposx);
        PlayerPrefs.SetFloat("playery", playerposy);
        PlayerPrefs.SetFloat("playerz", playerposz);
    }

    
}
