using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour {

	public ParticleSystem particlePrefeb;
	public bool AllowContinous = false;
	ParticleSystem currentParticle;

	// Use this for initialization
	void Start () {
		currentParticle = Instantiate(particlePrefeb);
		currentParticle.transform.position = gameObject.transform.position;
	}

	void PlayParticle() {
        if (currentParticle.isPlaying == false || AllowContinous) {
			currentParticle.transform.position = gameObject.transform.position;
			currentParticle.Play();
		}
	}
}