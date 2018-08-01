using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace TMPro.Examples
{
    public class Player_Attacks : MonoBehaviour
    {

        public TextMeshProUGUI healthtext;
        public static Attacks_Script attack;

        [SerializeField]
        public static int maxhealth;

        public Slider Healthslider;

        public static int health = 80;

        public static int stamina = 100;
        public GameObject enemy1, enemy2, enemy3;

        public TMPro.Examples.State_Machine statescript;
        public static bool hovering;
        public static GameObject whatishoveringover;

        public Slider staminaslider;
        public TextMeshProUGUI staminatext;

        public GameObject warningtextstamina;
        private void Update()
        {
            staminatext.text = ("Stamina: " + stamina.ToString());
            staminaslider.value = stamina;
            healthtext.text = ("HP: " + health);
            Healthslider.value = health;
            if (Input.GetMouseButtonDown(0) && hovering == true && whatishoveringover != null && statescript.currentState == TMPro.Examples.State_Machine.BattleStates.Playerchose && stamina <= attack.staminatake)
            {
                StartCoroutine(warning());
                    
            }
                if (Input.GetMouseButtonDown(0) && hovering == true && whatishoveringover != null && statescript.currentState == TMPro.Examples.State_Machine.BattleStates.Playerchose && stamina >= attack.staminatake)
            {
                TMPro.Examples.State_Machine.attackusedused = attack;
                TMPro.Examples.State_Machine.healamount = attack.heal;
                if (attack.dmgallteam == false)
                {
                    stamina += attack.staminafill;
                    
                    health += attack.heal;
                    if(health > maxhealth)
                    {
                        health = maxhealth;
                    }
                    whatishoveringover.GetComponent<Enemie_Display>().health -= attack.dmg;
                    stamina -= attack.staminatake;
                    TMPro.Examples.State_Machine.staminataken = attack.staminatake;
                    TMPro.Examples.State_Machine.attackbeingusedbyplayer = attack.Attack_Name;
                    TMPro.Examples.State_Machine.dmgbyplayertoenemy = attack.dmg;
                    TMPro.Examples.State_Machine.enemyattackedto = whatishoveringover.GetComponent<Enemie_Display>().enemie.Name;
                }
                if (attack.dmgallteam == true)
                {
                    stamina -= attack.staminatake;
                    TMPro.Examples.State_Machine.staminataken = attack.staminatake;
                    TMPro.Examples.State_Machine.attackbeingusedbyplayer = attack.Attack_Name;
                    TMPro.Examples.State_Machine.dmgbyplayertoenemy = attack.dmg;
                    TMPro.Examples.State_Machine.enemyattackedto = whatishoveringover.GetComponent<Enemie_Display>().enemie.Name;
                    if (enemy1 != null)
                    {
                        enemy1.GetComponent<Enemie_Display>().health -= attack.dmg;
                        TMPro.Examples.State_Machine.enemyattackedto = whatishoveringover.GetComponent<Enemie_Display>().enemie.Name;
                    }
                    if (enemy2 != null)
                    {
                        enemy2.GetComponent<Enemie_Display>().health -= attack.dmg;
                        TMPro.Examples.State_Machine.enemyattackedto = whatishoveringover.GetComponent<Enemie_Display>().enemie.Name;
                    }
                    if (enemy3 != null)
                    {
                        enemy3.GetComponent<Enemie_Display>().health -= attack.dmg;
                        TMPro.Examples.State_Machine.enemyattackedto = whatishoveringover.GetComponent<Enemie_Display>().enemie.Name;
                    }
                    TMPro.Examples.State_Machine.dmgbyplayertoenemy = attack.dmg;
                    TMPro.Examples.State_Machine.attackbeingusedbyplayer = attack.Attack_Name;
                    TMPro.Examples.State_Machine.dmgtoallenemy = true;
                }


                statescript.nextstate();
                TMPro.Examples.Attack_Button.pressed = false;
            }
            if (health <= 0)
            {
                TMPro.Examples.State_Machine.playerdead = true;
                Destroy(gameObject);
            }
        }
        private void Start()
        {
            maxhealth = 80;
            Healthslider.maxValue = maxhealth;

        }

        IEnumerator warning()
        {
            warningtextstamina.SetActive(true);
            yield return new WaitForSeconds(2);
            warningtextstamina.SetActive(false);
        }
            }

}
