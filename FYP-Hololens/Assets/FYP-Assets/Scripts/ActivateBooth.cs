using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBooth : MonoBehaviour {

	public GameObject booth;

	bool CollisionCheck = true;

	public bool GetCollisionCheck()
	{
		return CollisionCheck;
	}

	// Use this for initialization
	void Start () 
	{
		booth.SetActive(true);
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
		if (CheckCamera(collider))
		{
			CollisionCheck = true;
		}
	}

	void OnTriggerExit(Collider collider)
	{
		if (CheckCamera(collider))
		{
			CollisionCheck = false;
		}
	}

	void OnTriggerStay(Collider collider)
	{
		if (collider.transform.gameObject.tag != "monomino") 
		{
			//booth.transform.Rotate (Vector3.up * Time.deltaTime * 100);
			//Debug.Log (collider.transform.gameObject.name);
		}
	}
}
