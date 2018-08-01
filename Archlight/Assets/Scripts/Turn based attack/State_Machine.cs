using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TMPro.Examples
{
    public class State_Machine : MonoBehaviour
    {

        public enum BattleStates
        {
            Start,
            Playerchose,
            PlayerAnimation,
            Playerinfo,
            Enemyanimation,
            Enemyinfo,
            LOSE,
            WIN,
        }

        public GameObject Player;

        public GameObject Dialogbox;

        public TextMeshProUGUI dialogtext;

        public static string attackbyenemy;
        public static int dmgbeingdonebyenemy;
        public static bool dmgtoallenemy;
        public static string enemyattackedbuy;

        public static int staminataken;
        public static string attackbeingusedbyplayer;
        public static int dmgbyplayertoenemy;
        public static bool dmgtoallplayers;
        public static string enemyattackedto;
        public static int healamount;
        public static int staminaamount;

        public GameObject Enemy1;
        public Game_manager gamemanagerscript;
        [SerializeField]
        public static int deadenemys;

        public static bool playerdead;

        public GameObject Enemy2;
        public GameObject Enemy3;

        public GameObject button1, button2, button3, button4;
        public BattleStates currentState;
        public Enemie_Display enemiescript;
        public Enemie[] Enemiecards;

        public void nextstate()
        {
            if (currentState == BattleStates.Start)
            {
                currentState = BattleStates.Playerchose;
            }
            else
            {
                if (currentState == BattleStates.Playerchose)
                {
                    currentState = BattleStates.PlayerAnimation;
                }
                else
                {
                    if (currentState == BattleStates.PlayerAnimation)
                    {
                        currentState = BattleStates.Playerinfo;
                    }
                    else
                    {
                        if (currentState == BattleStates.Playerinfo)
                        {
                            currentState = BattleStates.Enemyanimation;
                        }
                        else
                        {
                            if (currentState == BattleStates.Enemyanimation)
                            {
                                currentState = BattleStates.Enemyinfo;
                            }
                            else
                            {
                                if (currentState == BattleStates.Enemyinfo)
                                {
                                    currentState = BattleStates.LOSE;
                                }
                                else
                                {
                                    if (currentState == BattleStates.LOSE)
                                    {
                                        currentState = BattleStates.WIN;
                                    }
                                    else
                                    {
                                        if (currentState == BattleStates.WIN)
                                        {
                                            currentState = BattleStates.Start;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        // Use this for initialization

        private bool selected;
        void Start()
        {
            currentState = BattleStates.Start;
            Enemie_Display a = Enemy1.GetComponent<Enemie_Display>();
            Enemie_Display b = Enemy2.GetComponent<Enemie_Display>();
            Enemie_Display c = Enemy3.GetComponent<Enemie_Display>();
            if (Game_manager.WhatEnemyAreYouFacing == "Sinister Crow")
            {
                Enemy2.SetActive(true);
                Enemy3.SetActive(true);
            }
            else
            {
                Enemy2.SetActive(false);
                Enemy3.SetActive(false);
            }
            foreach (Enemie e in Enemiecards)
            {
                if (e.name == Game_manager.WhatEnemyAreYouFacing)
                {

                    a.enemie = e;
                    b.enemie = e;
                    c.enemie = e;
                }
            }

        }


        private bool alreadyattacked;


        IEnumerator Enemyattacks()
        {
            alreadyattacked = true;
            if (Enemy1 != null)
            {
                Enemy1.GetComponent<Enemie_Display>().Attack();
                StartCoroutine(enemyinfodialog());
                while (enemyworking == true) { yield return null; }

            }
            if (Enemy2 != null && Enemy2.activeInHierarchy)
            {                                           
                    Enemy2.GetComponent<Enemie_Display>().Attack();
                    StartCoroutine(enemyinfodialog());
                    
                    if (Enemy3 == null)
                    {
                        yield return new WaitForSecondsRealtime(1);
                    }
                    if (Enemy3 != null)
                    {
                        while (enemyworking == true) { yield return null; }
                    }
                    
                
            }
            
            if (Enemy3 != null && Enemy3.activeInHierarchy)
            {              
                  Enemy3.GetComponent<Enemie_Display>().Attack();
                  StartCoroutine(enemyinfodialog());

                while (enemyworking == true) { yield return null; }




            }
            currentState = BattleStates.Playerchose;          
        }


        public void Win()
        {
            Dialogbox.SetActive(false);
            button1.SetActive(false);
            button4.SetActive(false);
            button3.SetActive(false);
            button2.SetActive(false);

            gamemanagerscript.windo();
            StartCoroutine(LoadScene());
            Dialogbox.SetActive(false);


        }

        IEnumerator LoadScene()
        {
            yield return null;
            SceneManager.LoadScene(2);
        }
        // Update is called once per frame
        void Update()
        {

            gamemanagerscript = GameObject.Find("Game manager").GetComponent<Game_manager>();


            switch (currentState)
            {
                case (BattleStates.LOSE):
                    deadenemys = 0;
                    break;


                case (BattleStates.Start):
                    nextstate();

                    break;





                case (BattleStates.Playerchose):
                    if (selected == false && currentState == BattleStates.Playerchose)
                    {
                        button1.SetActive(true);
                        button4.SetActive(true);
                        button3.SetActive(true);
                        button2.SetActive(true);
                        selected = true;
                    }


                    break;





                case (BattleStates.PlayerAnimation):
                    selected = false;
                    button1.SetActive(false);
                    button4.SetActive(false);
                    button3.SetActive(false);
                    button2.SetActive(false);
                    nextstate();
                    break;





                case (BattleStates.Playerinfo):
                    if(working == false)
                    {
                        StartCoroutine(playerinfodialog());
                    }              
                    break;





                case (BattleStates.Enemyanimation):
                    if (alreadyattacked == false)
                    {
                        StartCoroutine(Enemyattacks());
                    }
                    break;





                case (BattleStates.Enemyinfo):
                    alreadyattacked = false;
                    if (playerdead)
                    {
                        currentState = BattleStates.LOSE;
                    }

                    // or sign: || : if there is an enemy with more then 1 opponent put it here!
                    if (deadenemys >= 3 || deadenemys == 1 && Game_manager.WhatEnemyAreYouFacing != "Sinister Crow")
                    {
                        deadenemys = 0;
                        Win();
                    }
                    else
                    {
                        if (deadenemys < 3)
                        {

                            if (enemyworking == false)
                            {
                                StartCoroutine(enemyinfodialog());
                            }
                        }
                    }

                    break;




            }
        }
        public static int i;
        private float delay = 0.007f;
        private string currenttext = "";
        public string whattosay;
        private bool working;

        public static Attacks_Script attackusedused;

        IEnumerator playerinfodialog()
        {
            working = true;
            //if(attack.current = attack or heal
            if(attackusedused.current == Attacks_Script.State.attack)
            {
                whattosay = (Game_manager.Playername + " attacked a " + enemyattackedto + " with " + attackbeingusedbyplayer + " causing " + dmgbyplayertoenemy + " dmg to the enemy while taking " + staminataken + " stamina to do");
            }
            if (attackusedused.current == Attacks_Script.State.heal)
            {
                whattosay = (Game_manager.Playername + " healed " + healamount + "hp taking " + staminataken + " stamina points to do");
            }
            if (attackusedused.current == Attacks_Script.State.attackall)
            {
                whattosay = (Game_manager.Playername + " attacked all enemys with " + attackbeingusedbyplayer + " wich did " + dmgbyplayertoenemy + "dmg and took " + staminataken + " stamina to do");
            }
            if (attackusedused.current == Attacks_Script.State.stamina)
            {
                whattosay = (Game_manager.Playername + " refilled with " + attackusedused.staminafill + " more stamina");
            }
            Dialogbox.SetActive(true);
            for (i = 0; i < whattosay.Length + 1; i++)
            {
                currenttext = whattosay.Substring(0, i);
                dialogtext.text = currenttext;
                yield return new WaitForSeconds(delay);
            }
            
            yield return new WaitForSeconds(2);
            working = false;
            Dialogbox.SetActive(false);
            alreadyattacked = false;
            if (playerdead)
            {
                currentState = BattleStates.LOSE;
            }

            // or sign: || : if there is an enemy with more then 1 opponent put it here!
            if (deadenemys >= 3 || deadenemys == 1 && Game_manager.WhatEnemyAreYouFacing != "Sinister Crow")
            {
                deadenemys = 0;
                Win();
                Dialogbox.SetActive(false);
            } else
            {
                if (Enemy1 != null || Enemy2 != null || Enemy3 != null)
                {
                    currentState = BattleStates.Enemyanimation;
                }
            }       
           
        }

        public static int e;
        private string acurrenttext = "";
        public string awhattosay;
        private bool enemyworking;

        IEnumerator enemyinfodialog()
        {
            enemyworking = true;
            awhattosay = (enemyattackedbuy + " attacked " + Game_manager.Playername + " with " + attackbyenemy + " causing " + dmgbeingdonebyenemy + " dmg to " + Game_manager.Playername);
            Dialogbox.SetActive(true);
            for (i = 0; i < awhattosay.Length + 1; i++)
            {
                acurrenttext = awhattosay.Substring(0, i);
                dialogtext.text = acurrenttext;
                yield return new WaitForSeconds(delay);
            }
            yield return new WaitForSeconds(3);
            enemyworking = false;
            Dialogbox.SetActive(false);           
        }
    }

}


