using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

//Debugging Checklist
public class Self_Written_Control : MonoBehaviour {

	public TextMesh Using_VR_Check;
	public TextMesh Collided_Object_Text;
	public TextMesh Frame_Rate_Text;
	bool Using_VR = false;
	// Use this for initialization
	void Start () {
		Using_VR = VRDevice.isPresent;
		if (Using_VR) {
			Using_VR_Check.text = "Running VR devices";
		} else {
			Using_VR_Check.text = "Running Non VR devices";
		}
	}
	
	// Update is called once per frame
	void Update () {
		float FrameRate = 1 / Time.deltaTime;
		Frame_Rate_Text.text = FrameRate.ToString ();

		//Checking For Collided Object
		var headPosition = Camera.main.transform.position;
		var gazeDirection = Camera.main.transform.forward;

		RaycastHit hitInfo;
		if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
		{
			Collided_Object_Text.text = hitInfo.collider.gameObject.name;
		}
		else
		{
			Collided_Object_Text.text = "Null";
		}

	}
}
