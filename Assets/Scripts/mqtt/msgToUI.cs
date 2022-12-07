using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace Scripts.MQTTSpace
{

    public class msgToUI : MonoBehaviour
    {
        [SerializeField] TMP_Text MQTTmsg;

        static msgToUI instance;



        private void Awake()
        {
            if (instance == null)
            {
                if (MQTTmsg == null) throw new Exception("Falta TMPRO score");
            }
            else Destroy(gameObject);
        }

        public void UpdateMQTTtext(string msg)
        {
            MQTTmsg.text = msg.ToString();
        }


    }
}
