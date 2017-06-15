using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Sensor : MonoBehaviour {

	GameObject Collided_Object = null;

	public GameObject Get_Collided_Object (){
		return Collided_Object;
	}
	/*
	void OnTriggerEnter(Collider collider){
		Collided_Object = collider.transform.gameObject;
	}
	void OnTriggerExit(Collider collider){
			Collided_Object = null;
	}
	*/

	void Update(){
		Collided_Object = null;
	}

	void OnTriggerStay(Collider collider){
		Collided_Object = collider.transform.gameObject;
	}
}
