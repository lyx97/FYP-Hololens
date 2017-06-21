using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.VR.WSA.Input;

public class Interaction_Script1 : MonoBehaviour {

	public Transform Target_Slot;
	GameObject Lock_On_Object = null;
	bool Using_VR = false;
	Vector3 Slot_Default_Position;

	public static Interaction_Script1 Instance { get; private set; }

	// Represents the hologram that is currently being gazed at.
	public GameObject FocusedObject { get; private set; }

	GestureRecognizer recognizer;

	// Use this for initialization
	void Awake()
	{
		//check if using VR

		Using_VR = VRDevice.isPresent;
		Slot_Default_Position =Target_Slot.localPosition;
		if (Using_VR) {
			Instance = this;

			// Set up a GestureRecognizer to detect Select gestures.
			recognizer = new GestureRecognizer ();
			recognizer.TappedEvent += (source, tapCount, ray) => {
				// Send an message(or Trigger an Interection) to the focused object and its ancestors.
				if (FocusedObject != null|| Lock_On_Object != null) {
					//FocusedObject.SendMessageUpwards("OnSelect");
					LockOnTarget (FocusedObject);
				}
			};
			recognizer.StartCapturingGestures ();
		}
	}

	// Update is called once per frame
	void Update()
	{
		// Figure out which hologram is focused this frame.
		GameObject oldFocusObject = FocusedObject;

		// Do a raycast into the world based on the user's
		// head position and orientation.
		var headPosition = Camera.main.transform.position;
		var gazeDirection = Camera.main.transform.forward;

		RaycastHit hitInfo;
		if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
		{
			// If the raycast hit a hologram, use that as the focused object.
			FocusedObject = hitInfo.collider.gameObject;
			if (FocusedObject != Lock_On_Object) {
				Target_Slot.position = hitInfo.point;
			}
		}
		else
		{
			// If the raycast did not hit a hologram, clear the focused object.
			FocusedObject = null;
			Target_Slot.localPosition = Slot_Default_Position;
		}


		if (Using_VR) {
			// If the focused object changed this frame,
			// start detecting fresh gestures again.
			if (FocusedObject != oldFocusObject) {
				recognizer.CancelGestures ();
				recognizer.StartCapturingGestures ();
			}
		} else {
			if (Input.GetMouseButtonDown (0)) {
				if (FocusedObject != null || Lock_On_Object != null) {
					LockOnTarget (FocusedObject);
				}
			}
		}
	}

	void LockOnTarget(GameObject Target){

		if (Lock_On_Object == null) {
			Lock_On_Object = Target;
			Target.transform.SetParent(Target_Slot);
			Target.transform.position = Target_Slot.position;
			if (Lock_On_Object.GetComponent<Collider> ()) {
				Lock_On_Object.GetComponent<Collider> ().enabled = false;
			}
			if (Lock_On_Object.GetComponent<Rigidbody> ()) {
				Lock_On_Object.GetComponent<Rigidbody> ().isKinematic = true;
			}
		} else {
			Target_Slot.DetachChildren ();
			if (Lock_On_Object.GetComponent<Collider> ()) {
				Lock_On_Object.GetComponent<Collider> ().enabled = true;
			}
			if (Lock_On_Object.GetComponent<Rigidbody> ()) {
				Lock_On_Object.GetComponent<Rigidbody> ().isKinematic = false;
			}
			Lock_On_Object = null;
		}
	}
}
