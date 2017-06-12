using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Debug_Motion_Code : MonoBehaviour {

	public KeyCode Forward;
	public KeyCode Backward;
	public KeyCode Leftward;
	public KeyCode Rightward;
	public KeyCode Upward;
	public KeyCode Downward;

	public float Speed = 20;
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;

	bool Using_VR = false;
	// Use this for initialization
	void Start () {
		Using_VR = VRDevice.isPresent;
		if (Using_VR) {
			Destroy (this);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (Forward)) {
			this.transform.position += this.transform.forward * Speed * Time.deltaTime;
		}
		if (Input.GetKey (Backward)) {
			this.transform.position -= this.transform.forward * Speed * Time.deltaTime;
		}
		if (Input.GetKey (Rightward)) {
			this.transform.position += this.transform.right * Speed * Time.deltaTime;
		}
		if (Input.GetKey (Leftward)) {
			this.transform.position -= this.transform.right * Speed * Time.deltaTime;
		}
		if (Input.GetKey (Upward)) {
			this.transform.position += this.transform.up * Speed * Time.deltaTime;
		}
		if (Input.GetKey (Downward)) {
			this.transform.position -= this.transform.up * Speed * Time.deltaTime;
		}

		if (Input.GetMouseButton (1)) {
			float h = horizontalSpeed * Input.GetAxis("Mouse X");
			float v = -verticalSpeed * Input.GetAxis("Mouse Y");
			transform.Rotate(v, h, 0);
		}

	}
}
