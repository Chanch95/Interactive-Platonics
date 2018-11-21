using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {


	public GameObject items;
	int i=0;
	bool left;


	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown ("left")) {
			left = true;
		}

		if (Input.GetKeyDown ("right")) {
			left = false;
		}

		if (Input.GetKeyDown ("left") || Input.GetKeyDown ("right")) {
			

			if (i == 1) {
				if (left) {
					i--;
				}

				if (!left) {
					i++;
				}
				


				transform.position = new Vector3 (transform.position.x, transform.position.y, items.transform.GetChild (i).transform.position.z);
			}

			if (i ==2) {
				if (left) {
					i--;
				}
				transform.position = new Vector3 (transform.position.x, transform.position.y, items.transform.GetChild (i).transform.position.z);

			}

			if (i == 0) {
				if (!left) {
					i ++;
				}



				transform.position = new Vector3 (transform.position.x, transform.position.y, items.transform.GetChild (i).transform.position.z);

			}
		
		}
	}

	public void cool(){
		int j = 0;
		while (j == 0) {
			Update ();
		}


	}

}
