﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour {


    public GameObject mouselight;

    public int scenetochangeto;
	// Update is called once per frame
	void FixedUpdate () {

        Vector2 mousePosition = new Vector2(Input.mousePosition.x, (Input.mousePosition.y - 25));
        if(mouselight != null)
        {
            mouselight.transform.position = mousePosition;
        }

    }

    public void Switchtogame()
    {
        SceneManager.LoadScene(scenetochangeto);
    }
}
