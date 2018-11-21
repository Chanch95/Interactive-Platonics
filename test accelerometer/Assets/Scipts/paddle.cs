using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour {
	public float distance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.RightArrow))
		{
			Vector2 temp = transform.position;
			temp.x += distance * Time.deltaTime;
			transform.position = temp;
		}

		if (Input.GetKey (KeyCode.LeftArrow))
		{
			Vector2 temp = transform.position;
			temp.x -= distance * Time.deltaTime;
			transform.position = temp;
		}
	}
}
