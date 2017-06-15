using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Animation : MonoBehaviour {

	public Animator Animation_;
	// Use this for initialization
	void Start () {
		Animation_.Play ("Walk");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
