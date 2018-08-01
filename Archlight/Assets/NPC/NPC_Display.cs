using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TMPro.Examples
{
    public class NPC_Display : MonoBehaviour
    {

        public NPC npc;

        public GameObject dialogbox, headbox;

        public TextMeshProUGUI dialognamebox;
        public TextMeshProUGUI dialogtextbox;

        
        public static GameObject talkingtonpc;


        // Use this for initialization

        private void Start()
        {
            FindObjectOfType<AudioManager>().Play("Test");
            dialogbox.SetActive(false);
            headbox.SetActive(false);
        }
        void Update()
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = npc.idle_anim;
            if(talkingtonpc = gameObject)
            {
                if (Dialog.dialogpage == npc.Dialogs.Length)
                {
                    i = 0;
                    dialogbox.SetActive(false);
                    headbox.SetActive(false);
                    Dialog.dialogpage = 0;
                } else
                {
                    if(Dialog.pressed == true)
                    {
                        if(working == false)
                        {
                            StartCoroutine(textshow());

                        }
                        Dialog.pressed = false;
                    }
                }

            }
            if(Dialogoutside.inside == false)
            {
                i = 0;
                dialogbox.SetActive(false);
                headbox.SetActive(false);
                Dialog.dialogpage = 0;

            }
        }
        public static int i;
        public float delay = 0.5f;
        private string currenttext = "";
        private bool working;
        IEnumerator textshow()
        {          
            working = true;
            if(dialogbox.activeInHierarchy == true)
            {
                for (i = 0; i < npc.Dialogs[Dialog.dialogpage].Length; i++)
                {
                    currenttext = npc.Dialogs[Dialog.dialogpage].Substring(0, i);
                    dialogtextbox.text = currenttext;
                    yield return new WaitForSeconds(delay);
                }
            } else
            {
                i = 0;
            }

            working = false;
        }
        public void DialogStart()
        {
            headbox.GetComponent<Image>().sprite = npc.headimg;
            headbox.SetActive(true);
            dialogbox.SetActive(true);
            dialognamebox.text = npc.NPC_Name;
            
        }
        private void OnTriggerEnter2D(Collider2D col)
        {

            if(col.gameObject.tag == "Player")
            {
                i = 0;
                talkingtonpc = gameObject;
                DialogStart();
                Dialog.pressed = true;
            }
        }
       

    }

}