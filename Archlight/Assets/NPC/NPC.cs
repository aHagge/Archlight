using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPC : ScriptableObject {

    public string NPC_Name;

    public Sprite idle_anim;

    public string[] Dialogs;

}
