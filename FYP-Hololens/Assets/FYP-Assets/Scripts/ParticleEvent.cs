using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour {

	public ParticleSystem particlePrefeb;
	public bool AllowContinous = false;
	ParticleSystem currentParticle;

	// Use this for initialization
	void Start () {
		currentParticle = Instantiate(particlePrefeb, particlePrefeb.transform.position, particlePrefeb.transform.rotation, gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void PlayParticle() {
        //currentParticle.gameObject.transform.position = particleSystem.gameObject.transform.position;
        if (currentParticle.isPlaying == false || AllowContinous) {
			currentParticle.Play();
		}
	}
}
