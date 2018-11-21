using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class ultra2 : MonoBehaviour {

	SerialPort stream = new SerialPort("/dev/tty.usbmodem1411", 9600); //Set the port (com4) and the baud rate (9600, is standard on most devices)
	//	float[] lastRot = {0,0,0}; //Need the last rotation to tell how far to spin the camera

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
		if (value != "") {
			//transform.localScale = new Vector3 (transform.localScale.x,int.Parse(value),transform.localScale.y);
		//	transform.localScale = new Vector4(int.Parse(value),int.Parse(value),int.Parse(value),0);
			transform.localScale = new Vector3(int.Parse(value),int.Parse(value),int.Parse(value));
		}
	}

	void OnGUI()
	{
	//	string newString = "Connected: " + transform.rotation.x + ", " + transform.rotation.y + ", " + transform.rotation.z;
	//	GUI.Label(new Rect(10,10,300,100), newString); //Display new values
		// Though, it seems that it outputs the value in percentage O-o I don't know why.
	}
}