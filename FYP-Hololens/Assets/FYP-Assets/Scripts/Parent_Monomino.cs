using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_Monomino : MonoBehaviour {

	public GameObject childToSpawn;
	public ParticleSystem despawnParticle;
	public int amountOfChildren;
	public float cooldown;

	float Current_CD = 0;
	GameObject[] childrenArray;
	ParticleSystem[] despawnParticleArray;

	public void Child_Died(GameObject Child){
		ParticleSystem Suitable_Death_Particles = Get_Valid_Particles();
		if (Suitable_Death_Particles) {
			Suitable_Death_Particles.transform.position = Child.transform.position;
			Suitable_Death_Particles.transform.rotation = Random.rotation;
			Suitable_Death_Particles.Play();
		}
		Disable_Children (Child);
	}

	ParticleSystem Get_Valid_Particles(){
		for (int i = 0; i < amountOfChildren; i++) {
			if (despawnParticleArray[i].IsAlive() == false) {
				return despawnParticleArray[i];
			}
		}
		return null;
	}

	// Use this for initialization
	void Start () {
		childrenArray = new GameObject[amountOfChildren];
		despawnParticleArray = new ParticleSystem[amountOfChildren];
		for (int i = 0; i < amountOfChildren; i++) {
			childrenArray[i] = Instantiate (childToSpawn);
			if (childrenArray[i].GetComponent<Child_Monomino> ()) {
				childrenArray[i].GetComponent<Child_Monomino> ().Set_Parent (this);
			}
			Disable_Children(childrenArray[i]);
			despawnParticleArray[i] = Instantiate(despawnParticle);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Current_CD <= 0) {
			GameObject Spawned_Child = Spawn_Children_When_Possible();
			if (Spawned_Child != null)
			{
				Enabled_Children(Spawned_Child);
			}
			Current_CD += cooldown;
		} else {
			Current_CD -= Time.deltaTime;
		}
	}

	GameObject Spawn_Children_When_Possible() {
		//Hunt for a valid Child
		GameObject Chosen_Child = null;
		for (int i = 0; i < amountOfChildren; i++) {
			if (childrenArray[i].activeSelf == false) {
				Chosen_Child = childrenArray[i];
				break;
			}
		}
		return Chosen_Child;
	}

	//Used to disable gameobjects
	void Disable_Children(GameObject Child){
		Child.SetActive (false);
	}

	//Used to enable gameobjects
	void Enabled_Children(GameObject Child){
		Child.SetActive (true);
		Child.transform.position = this.transform.position;
		Child.transform.rotation = this.transform.rotation;
		if (Child.GetComponent<Rigidbody>()) {
			Child.GetComponent<Rigidbody>().velocity = new Vector3();
		}
	}
}
