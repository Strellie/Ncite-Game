using UnityEngine;
using System.Collections;

public class PlayerMovment : MonoBehaviour {

	public float speed = 10;
	public Rigidbody rb;

	// Use this for initialization
	void Start () {
	
		rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
	
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");

		//Vector3 movement = new Vector3(0,0, 0+vAxis) * speed * Time.deltaTime;
		Vector3 movement = transform.forward * vAxis * speed * Time.deltaTime;
		//Quaternion rotation = Quaternion.Euler(0, 0 , 0 + hAxis);
		if(Input.GetButtonDown("Jump")){
			rb.AddForce(Vector3.up*300);
		}
		rb.MovePosition(transform.position + movement);
		transform.Rotate(Vector3.up, hAxis * Time.deltaTime * 200);


	}
}
