using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControllerScript : MonoBehaviour {
	public GameObject DanbocchiObject;
	public GameObject DoorObject;
	public GameObject FrontPanelObject;
	public GameObject RightPanelObject;
	public GameObject LeftPanelObject;
	public GameObject RearPanelObject;
	public GameObject RoofPanelObject;
	public GameObject SilencerObject;

	bool rotateFlag = false;
	bool doorFlag = false;
	bool panelFlag = false;
	float speed = 0.02f;
	float dt, pt;
	Vector3 frontPanelPos;
	Vector3 rightPanelPos;
	Vector3 leftPanelPos;
	Vector3 rearPanelPos;
	Vector3 roofPanelPos;
	Vector3 silencerPos;

	// Use this for initialization
	void Start () {
		dt = 1f;
		pt = 1f;
		frontPanelPos = FrontPanelObject.transform.localPosition;
		rightPanelPos = RightPanelObject.transform.localPosition;
		leftPanelPos = LeftPanelObject.transform.localPosition;
		rearPanelPos = RearPanelObject.transform.localPosition;
		roofPanelPos = RoofPanelObject.transform.localPosition;
		silencerPos = SilencerObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		dt += speed;
		Mathf.Clamp01 (dt);
		float doorAngle;
		if (doorFlag) {
			doorAngle = Mathf.LerpAngle (0f, 120f, dt);
		} else {
			doorAngle = Mathf.LerpAngle (120f, 0f, dt);
		}
		DoorObject.transform.localEulerAngles = new Vector3 (0, doorAngle, 0);

		if (rotateFlag) {
			DanbocchiObject.transform.Rotate (new Vector3 (0, 30, 0) * Time.deltaTime);
		}

		pt += speed;
		Mathf.Clamp01 (pt);
		float panelDistance;
		if (panelFlag) {
			panelDistance = Mathf.Lerp (0f, 0.2f, pt);
		} else {
			panelDistance = Mathf.Lerp (0.2f, 0f, pt);
		}
		FrontPanelObject.transform.localPosition = new Vector3 (frontPanelPos.x, frontPanelPos.y, frontPanelPos.z - panelDistance);
		RightPanelObject.transform.localPosition = new Vector3 (rightPanelPos.x + panelDistance, rightPanelPos.y, rightPanelPos.z);
		LeftPanelObject.transform.localPosition = new Vector3 (leftPanelPos.x - panelDistance, leftPanelPos.y, leftPanelPos.z);
		RearPanelObject.transform.localPosition = new Vector3 (rearPanelPos.x , rearPanelPos.y, rearPanelPos.z + panelDistance);
		RoofPanelObject.transform.localPosition = new Vector3 (roofPanelPos.x , roofPanelPos.y + panelDistance, roofPanelPos.z);
		SilencerObject.transform.localPosition = new Vector3 (silencerPos.x , silencerPos.y + (panelDistance * 2f), silencerPos.z);
	}

	public void OnDoorButton () {
		dt = 0f;
		doorFlag = !doorFlag;
	}

	public void OnRotateButton() {
		rotateFlag = !rotateFlag;
	}

	public void OnAssembleButton() {
		pt = 0f;
		panelFlag = !panelFlag;
	}
}
