using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public static Vector2 positionofenemie;
    public static bool seeme;

    
    public static bool pressed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 mousePosition = new Vector2((Input.mousePosition.x + 15), Input.mousePosition.y);
        gameObject.transform.position = mousePosition;

        if(TMPro.Examples.Player_Attacks.hovering == false)
        {
            gameObject.SetActive(false);
        }
    }
}
