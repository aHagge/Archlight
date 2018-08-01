using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attack")]
public class Attacks_Script : ScriptableObject
{

    public string Attack_Name;

    public string description;
    public int dmg;

    public int heal;

    public int staminatake;

    public int staminafill;

    public bool dmgallteam;
    public bool healallteam;

    public enum State
    {
        attack, heal, healall, attackall, stamina, staminaall
    }

    public State current;
    
}
