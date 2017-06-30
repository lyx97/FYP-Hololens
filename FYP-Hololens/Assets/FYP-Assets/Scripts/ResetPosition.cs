using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

	public GameObject gameobjectToReset;
	private Vector3 originalPosition;

	// Use this for initialization
	void Start () {
		originalPosition = gameobjectToReset.transform.position;
		originalPosition.y += 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameobjectToReset.transform.position.y <= -10)
		{
			gameobjectToReset.transform.position = originalPosition;
			gameobjectToReset.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
		}
	}
}
