using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour {
	
	float launchForce = 0;

	
	Vector3 startPosition;
	Quaternion startRotation;

	
	bool playerWon = false;

	
	void Start () {
		startPosition = transform.position;
		startRotation = transform.rotation;
	}
	
	
	void Update () {
		
		if (Input.GetKeyUp(KeyCode.Space)) {
			
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			
			rb.useGravity = true;
			
		    rb.AddForce(transform.forward * launchForce);
		}

		
		if (Input.GetKey(KeyCode.Space)) {
			launchForce = launchForce + 3f;
		} else {
			
			if (launchForce > 0) {
				launchForce = launchForce - 3f;
			}
		}
	}

	
	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.name == "invisble") {
			playerWon = true;
		}

		if (other.gameObject.name == "invisbleback") {
			
			Rigidbody rb = gameObject.GetComponent<Rigidbody>();
			rb.useGravity = false;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;

			
			gameObject.transform.position = startPosition;
			
			gameObject.transform.rotation = startRotation;
		}
	}


	private void OnGUI()
	{
		GUI.Label(new Rect(50, 50, 200, 200), launchForce.ToString());

		if (playerWon) {
			GUI.Label(new Rect(250, 250, 200, 200), "You are a hero!");
		}
	}
}
