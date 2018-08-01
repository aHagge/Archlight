using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_MOV : MonoBehaviour
{

    public bool anythinginslot;

    private void FixedUpdate()
    {
        if (transform.childCount != 0)
        {
            anythinginslot = true;
        }
        if (transform.childCount == 0)
        {
            anythinginslot = false;
        }
    }
}