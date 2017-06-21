using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {

	public GameObject Child;

	// Use this for initialization
	void Start () 
	{
		Child.SetActive (false);
	}

	bool CheckCamera(Collider collider)
	{
		if (collider.transform.gameObject == Camera.main.transform.gameObject)
			return true;
		else
			return false;
	}


	void OnTriggerEnter(Collider collider)
	{
		if (CheckCamera (collider)) {
			Debug.Log (collider.transform.gameObject.name);
			Child.SetActive (true);
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (CheckCamera (collider))
			Child.SetActive (false);
	}

	void OnTriggerStay(Collider collider)
	{
		Debug.Log ("UPDATING THIS CUBE");
		Child.transform.Rotate (Vector3.up * Time.deltaTime * 10);
	}
}
