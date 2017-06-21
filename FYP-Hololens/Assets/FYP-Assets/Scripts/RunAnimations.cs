using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAnimations : MonoBehaviour {

	ActivateBooth MotherBooth;
	public Animator Animation;

	// Use this for initialization
	void Start () {
		MotherBooth = (ActivateBooth)FindObjectOfType (typeof(ActivateBooth));
	}
	
	// Update is called once per frame
	void Update () {
		bool Active = MotherBooth.GetCollisionCheck();
		Animation.SetBool("close to booth", Active);
	}
}
