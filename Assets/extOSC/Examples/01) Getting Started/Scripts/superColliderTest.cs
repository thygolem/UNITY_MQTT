using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace extOSC.Examples
{

// 57120 is the default port for SuperCollider
public class superColliderTest : MonoBehaviour
{
		#region Public Vars

		public string Address = "/example/1";

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion

		#region Unity Methods

		public void Start()
		{
			var message = new OSCMessage(Address);
			message.AddValue(OSCValue.String("Hello, M!"));

			Transmitter.Send(message);
		}

        public void SendOSCMessage()
        {
            var oscMessage = new OSCMessage(Address);
			oscMessage.AddValue(OSCValue.String("Hello, M!"));

            // oscMessage.AddValue(OSCValue.String(message));

            Transmitter.Send(oscMessage);
        }
		#endregion
	}
}