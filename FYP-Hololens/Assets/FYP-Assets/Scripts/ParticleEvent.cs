using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEvent : MonoBehaviour
{

	public ParticleSystem[] particleArray;
	public bool AllowContinous = false;
	ParticleSystem[] currentParticle;

	// Use this for initialization
	void Start ()
	{
		currentParticle = new ParticleSystem[particleArray.Length];
		for (int i = 0; i < particleArray.Length; ++i)
		{
			currentParticle[i] = Instantiate(particleArray[i]);
		}
	}

	void PlayParticle(int index)
	{
		if (!currentParticle[index].isPlaying || AllowContinous)
		{
			currentParticle[index].transform.position = gameObject.transform.position;
			currentParticle[index].Play();
		}
	}
}