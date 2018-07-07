using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour {
    public static int dialogpage;
    public static bool pressed;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void nextdialogpage()
    {
        TMPro.Examples.NPC_Display.i = 0;
        pressed = true;
        dialogpage++;
    }
}
