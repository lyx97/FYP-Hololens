using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Sensor : MonoBehaviour {

	GameObject Collided_Object = null;
	public Collider[] Self_Collision;

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

	bool Collider_Check(Collider collider){
		for (int i = 0; i < Self_Collision.Length; i++) {
			if (collider == Self_Collision[i]) {
				return false;
			}
		}
		return true;
	}

	void OnTriggerStay(Collider collider){
		if (Collider_Check (collider)) {
			Collided_Object = collider.transform.gameObject;
		}
	}
}
