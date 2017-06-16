using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_Monomino : MonoBehaviour {

	[Tooltip("Must Trigger To Move Forward")]
	public Trigger_Sensor Feet;
	[Tooltip("Must Trigger To Climb up")]
	public Trigger_Sensor Hand;
	[Tooltip("Maximum Falling Speed")]
	public float kill_speed = -20;
	[Tooltip("Animator ot control animation")]
	public Animator animator_ = null;

	public float Climbing_Speed = 1;
	public float Moving_Speed = 1;

	public float Max_Speed = 20;


	[Tooltip("Used To Displace the child so he can move forward when the climbing ended")]
	public float Forward_Push_Distance = 0.1f;
	[Tooltip("Used To Displace the child so he can move upward when the climbing ended")]
	public float Upward_Push_Distance = 0.1f;
	Rigidbody Body;
	Parent_Monomino parent;
 
	public void Set_Parent(Parent_Monomino I_parent){
		parent = I_parent;
	}

	// Use this for initialization
	void Start () {
		Body = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Body.velocity.y <= kill_speed) {
			Body.velocity = new Vector3 (0, 0, 0);
			parent.Child_Died (this.transform.gameObject);
		}

		if (Hand.Get_Collided_Object () == null && Body.useGravity == false) {
			Body.useGravity = true;
			this.transform.position += new Vector3 (0,Upward_Push_Distance,Forward_Push_Distance);
			Body.velocity = new Vector3 (0, 0, 0);
		}
		else if (Hand.Get_Collided_Object () != null && Body.useGravity == true) {
			Body.useGravity = false;
			Body.velocity = new Vector3 (0, 0, 0);
		}


		if (Hand.Get_Collided_Object ()) {
			//Climbing/Jumping
			animator_.SetTrigger ("Jumping");
			Body.AddForce (Vector3.up * Climbing_Speed, ForceMode.Acceleration);
		}
		else if (Feet.Get_Collided_Object () != null) {
			//Climbing/Jumping
			animator_.SetTrigger ("Walking");
			Body.AddForce (this.transform.gameObject.transform.forward * Moving_Speed, ForceMode.Acceleration);
			}
		else {
			//start of Falling?
				animator_.SetTrigger ("Falling");
				Vector3 Velocity = Body.velocity;
				Velocity.x = Velocity.z = 0;
				Body.velocity = Velocity;
		}

		//Cap Velocity
		if (Body.velocity.magnitude > Max_Speed) {
			Body.velocity = Body.velocity.normalized * Max_Speed;
		}
	}
}
