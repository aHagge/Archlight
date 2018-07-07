using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    namespace TMPro.Examples
{
    public class HPDISPLAY : MonoBehaviour
    {
        public TextMeshProUGUI hptext;

        private void FixedUpdate()
        {
            if(hptext != null)
            {
                hptext.text = ("HP: " + gameObject.GetComponent<Enemie_Display>().health.ToString());
            }
        }
    }
}
