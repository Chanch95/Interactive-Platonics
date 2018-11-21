using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class serialRotation : MonoBehaviour {

	SerialPort stream = new SerialPort("/dev/tty.usbmodem1411", 9600); //Set the port (com4) and the baud rate (9600, is standard on most devices)
	float[] lastRot = {0,0,0}; //Need the last rotation to tell how far to spin the camera

	void Start () {
		if (stream.IsOpen == true)
			print ("hello");
		else
			print ("false");
		
		stream.Open(); //Open the Serial Stream.
	}

	// Update is called once per frame
	void Update () {
		string value = stream.ReadLine(); //Read the information
		string[] vec3 = new string[3];
		vec3 = value.Split(','); //My arduino script returns a 3 part value (IE: 12,30,18)
		print(vec3[0]);
		print(vec3[1]);
		print(vec3[2]);
//		print (vec3 [3]);
//		print (vec3 [4]);
		if (vec3[0] != "" && vec3[1] != "" && vec3[2] != "" ) 
		{
			transform.Rotate(           //Rotate the camera based on the new values
				float.Parse(vec3[1])-lastRot[1],
				float.Parse(vec3[2])-lastRot[2],
				float.Parse(vec3[3])-lastRot[3],
				Space.Self 
			);
			lastRot[1] = float.Parse(vec3[1]);  //Set new values to last time values for the next loop
			lastRot[2] = float.Parse(vec3[2]);
			lastRot[3] = float.Parse(vec3[3]);
//			transform.localScale = new Vector4(int.Parse(vec3[1]),int.Parse(vec3[1]),int.Parse(vec3[1]),0);
			stream.BaseStream.Flush(); //Clear the serial information so we assure we get new information.

		}
	}

	void OnGUI()
	{
		string newString = "Connected: " + transform.rotation.x + ", " + transform.rotation.y + ", " + transform.rotation.z;
		GUI.Label(new Rect(10,10,300,100), newString); //Display new values
		// Though, it seems that it outputs the value in percentage O-o I don't know why.
	}
}