using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour {

	public ParticleSystem particleSystem;
	public bool AllowContinous = false;
	ParticleSystem currentParticle;

	// Use this for initialization
	void Start () {
		currentParticle = Instantiate(particleSystem, this.transform.position, particleSystem.gameObject.transform.rotation);
		currentParticle.gameObject.transform.DetachChildren ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void PlayParticle() {
		//particleSystem.Emit (1);
		if (currentParticle.isPlaying == false || AllowContinous) {
			currentParticle.Play();
		}
	}
}
