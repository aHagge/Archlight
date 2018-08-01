using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject inventoryhub;
    public GameObject armorinventoryhub;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(inventoryhub.activeInHierarchy)
            {
                inventoryhub.SetActive(false);
                armorinventoryhub.SetActive(false);
            } else
            {
                inventoryhub.SetActive(true);
                armorinventoryhub.SetActive(true);
            }
        }
    }
}
