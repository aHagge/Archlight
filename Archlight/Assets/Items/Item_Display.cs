using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples
{
    public class Item_Display : MonoBehaviour
    {


        public Items item;
        public Vector3 latesttouchpos;


        public Transform canvas;
        private bool mouseover;

        private bool inhand;   

        public TextMeshProUGUI numberof;

        public int howmanycanstack;
        public bool cantstack;

        public int howmanyinslot;

        public bool full;

        public void OnMouseEnte()
        {
            mouseover = true;
        }
        public void OnMouseExi()
        {
            mouseover = false;
        }


        // Use this for initialization
        void Start()
        {
            howmanyinslot = 1;
            howmanycanstack = item.HowManyCanStack;
            if(cantstack)
            {
                howmanycanstack = 1;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            gameObject.GetComponent<Image>().sprite = item.sprite;

        }

        private void FixedUpdate()
        {
            numberof.text = howmanyinslot.ToString();
            if (canvas == null)
            {
                canvas = GameObject.Find("UI").transform;
            }
        }


        // Update is called once per frame
        void Update()
        {

            if (mouseover && Input.GetMouseButtonDown(0))
            {
                inhand = true;
            }

            if (inhand)
            {
                transform.position = new Vector2((Input.mousePosition.x), Input.mousePosition.y);
            }
            if (Input.GetMouseButtonUp(0))
            {
                inhand = false;
                transform.position = transform.parent.position;
                
            }
        }

        // transform.position = new Vector2((Input.mousePosition.x), Input.mousePosition.y);
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Slot")
            {
                if(col.gameObject.GetComponent<Item_MOV>().anythinginslot)
                {
                    if(col.gameObject.GetComponentInChildren<Item_Display>().item == item)
                    {
                        //Check if we even can combine them
                        if (col.gameObject.GetComponentInChildren<Item_Display>().howmanycanstack >=
                            col.gameObject.GetComponentInChildren<Item_Display>().howmanyinslot + howmanyinslot)
                        {
                            //Combine them
                            col.gameObject.GetComponentInChildren<Item_Display>().howmanyinslot += howmanyinslot;
                            //TERMINATE THIS OBJECT MUAHHAHAAHA
                            Destroy(gameObject);
                        }
                    }
                    
                }
              
                //transform.SetParent(col.gameObject.transform);
                //transform.parent.GetComponent<Item_MOV>().anythinginslot = true;
            }

            if (col.gameObject.tag == "Slot" && !col.gameObject.GetComponent<Item_MOV>().anythinginslot)
            {
                transform.SetParent(col.gameObject.transform);
                transform.parent.GetComponent<Item_MOV>().anythinginslot = true;
            }



        }
        private void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.tag == "Slot" && !col.gameObject.GetComponent<Item_MOV>().anythinginslot)
            {
                transform.SetParent(col.gameObject.transform);
                transform.parent.GetComponent<Item_MOV>().anythinginslot = true;
            }
            
        }
        private void OnTriggerExit2D(Collider2D col)
        {
            
            if(transform.childCount > 0)
            {
                transform.parent.GetComponent<Item_MOV>().anythinginslot = false;
            }
        }
    }

}

