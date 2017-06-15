using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parent_Monomino : MonoBehaviour {

	public GameObject Child_To_Spawn;
	public ParticleSystem Death_Particle_To_Spawn;
	public int Child_Amount;
	public float Cooldown_Time;

	float Current_CD = 0;
	GameObject[] Childrens;
	ParticleSystem[] Death_Particles;

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
		for (int i = 0; i < Child_Amount; i++) {
			if (Death_Particles [i].IsAlive() == false) {
				return Death_Particles [i];
			}
		}
		return null;
	}

	// Use this for initialization
	void Start () {
		Childrens = new GameObject[Child_Amount];
		Death_Particles = new ParticleSystem[Child_Amount];
		for (int i = 0; i < Child_Amount; i++) {
			Childrens[i] = Instantiate (Child_To_Spawn);
			if (Childrens [i].GetComponent<Child_Monomino> ()) {
				Childrens [i].GetComponent<Child_Monomino> ().Set_Parent (this);
			}
			Disable_Children (Childrens[i]);
			Death_Particles [i] = Instantiate (Death_Particle_To_Spawn);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Current_CD <= 0) {
			GameObject Spawned_Child = Spawn_Children_When_Possible ();
			if(Spawned_Child != null)
			{
				Enabled_Children (Spawned_Child);
			}
			Current_CD += Cooldown_Time;
		} else {
			Current_CD -= Time.deltaTime;
		}
	}

	GameObject Spawn_Children_When_Possible (){
		//Hunt for a valid Child
		GameObject Chosen_Child = null;
		for (int i = 0; i < Child_Amount; i++) {
			if(Childrens[i].activeSelf == false){
				Chosen_Child = Childrens[i];
				break;
				}
		}
		return Chosen_Child;
	}

	//Used To Disable A gmaeobjects
	void Disable_Children(GameObject Child){
		Child.SetActive (false);

	}

	//Used To ensable A gmaeobjects
	void Enabled_Children(GameObject Child){
		Child.SetActive (true);
		Child.transform.position = this.transform.position;
		Child.transform.rotation = this.transform.rotation;
		if (Child.GetComponent<Rigidbody> ()) {
			Child.GetComponent<Rigidbody> ().velocity = new Vector3 ();
		}
	}
}
