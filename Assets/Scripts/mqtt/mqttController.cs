using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Scripts.MQTTSpace
{
    public class mqttController : MonoBehaviour
    {
        public string nameController = "Controller 1";
        public string tagOfTheMQTTReceiver = "MQTT";
        public mqttReceiver _eventSender;

        void Start()
        {
            _eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<mqttReceiver>();
            _eventSender.OnMessageArrived += OnMessageArrivedHandler;
        }

        private void OnMessageArrivedHandler(string newMsg)
        {
            Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
        }
    }
}