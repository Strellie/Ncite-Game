using UnityEngine;
using System.Collections;

public class Companion : MonoBehaviour {

	public Transform player;
	public Transform lookAtPlayer;

	public float speed = 10;
	public Rigidbody rb;

	public Timer timer;
	public Timer timer2;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
		//timer.GetComponent<Timer>();
		timer = new Timer();
		timer2 = new Timer();
	}
	
	// Update is called once per frame
	void Update () {

		Quaternion rotation = Quaternion.Euler(0, lookAtPlayer.rotation.y , 0);
		//Quaternion rotation = Quaternion.identity;
		//rotation.eulerAngles = new Vector3(0, 0, lookAtPlayer.rotation.y);

		timer2.CountDown(20,4);
		if(timer.CountUp(0,4))
			timer.ResetTimer();
		//timer.GetCurrentTime;
		print(timer.ToString());
		print(timer2.ToString());

		Vector3 movement = transform.forward * speed * Time.deltaTime;
		if(Vector3.Distance(transform.position, player.position) > 4)
			//rb.MovePosition(transform.position + movement);
			transform.position = Vector3.Lerp(transform.position, transform.position + movement, 0.5F);
		//transform.Rotate(Vector3.up, Time.deltaTime * 200);
		//transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.5F);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtPlayer.rotation, 100*Time.deltaTime);
		//transform.LookAt(player);
	
	}
}
