using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemie", menuName = "Enemie")]
public class Enemie : ScriptableObject
{
    
    public string Name;

    public string description;

    public Sprite Icon;
    public Sprite flocksprite;
    public Sprite[] idleanim;
    public Sprite look;

    public int Health;

    public Vector2 size;

    public string Attack1;
    public int attack1_dmg;

    public string Attack2;
    public int attack2_dmg;

    public string Attack3;
    public int attack3_dmg;
}

