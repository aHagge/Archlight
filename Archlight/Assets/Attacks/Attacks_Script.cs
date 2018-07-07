using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class Attacks_Script : ScriptableObject
{

    public string Attack_Name;

    public int dmg;

    public int heal;

    public int staminatake;

    public int staminafill;

    public bool dmgallteam;
    public bool healallteam;

}
