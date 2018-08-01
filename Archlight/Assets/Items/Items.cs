using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Items : ScriptableObject
{
    public string Name;
    public Sprite sprite;

    public string description; 

    public int HowManyCanStack = 1;
    
    public enum State
    {
        standard, chestplate, leggings, helmet, boots, rings, lures
    }

    public State current;

}
