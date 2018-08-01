﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TMPro.Examples
{
    public class Attack_Button : MonoBehaviour
    {
        public GameObject button2,button3,button4;

        public static bool pressed;

        public GameObject statobject;

        public TextMeshProUGUI Text;

        public GameObject parent;

        public Attacks_Script attack;

        public GameObject aimsight;
        void Start()
        {
            Text.text = attack.Attack_Name;
            parent.SetActive(false);
            statobject.SetActive(false);
        }

        public void Usetheability()
        {
            pressed = true;
            Player_Attacks.attack = attack;
            parent.SetActive(false);
            statobject.SetActive(true);
            statobject.GetComponentInChildren<TextMeshProUGUI>().text = attack.description;
            button2.SetActive(true);
            button3.SetActive(true);
            button4.SetActive(true);
        }


    }

}