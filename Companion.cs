using UnityEngine;
using System.Collections;

public class Companion : MonoBehaviour {

	public Transform player;
	public Transform lookAtPlayer;

	public Transform wayPoint;

	public GameObject rightWayPoint;
	public GameObject leftWayPoint;

	public float speed = 10;
	public Rigidbody rb;

	public Timer timer;

	public bool rightStep = false;
	public bool leftStep = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
		timer = new Timer();
		//timer.GetComponent<Timer>()
	}
	
	// Update is called once per frame
	void Update () {

		Quaternion rotation = Quaternion.Euler(0, lookAtPlayer.rotation.y , 0);
		//Quaternion rotation = Quaternion.identity;
		//rotation.eulerAngles = new Vector3(0, 0, lookAtPlayer.rotation.y);


		Vector3 movement = transform.forward * speed * Time.deltaTime;
		if(/*wayPoint != null*/ rightStep ){
			if(timer.CountDown(0.2F)){
				rightStep = false;
				timer.ResetTimer();
			}
			//transform.position = Vector3.Lerp(transform.position, wayPoint.position, 0.05F);
			//transform.position = Vector3.Lerp(transform.position, transform.position, 0.05F);
			gameObject.GetComponent<Rigidbody>().AddForce(transform.right * 20);
			//transform.LookAt(wayPoint);
			//transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtPlayer.rotation, 100*Time.deltaTime);
		}else if(/*wayPoint != null*/ leftStep ){
			if(timer.CountDown(0.2F)){
				leftStep = false;
				timer.ResetTimer();
			}
			gameObject.GetComponent<Rigidbody>().AddForce(transform.right * -20);
		}else if(Vector3.Distance(transform.position, player.position) > 4 && wayPoint == null){
			//rb.MovePosition(transform.position + movement);
			transform.position = Vector3.Lerp(transform.position, transform.position + movement, 0.5F);
		//transform.Rotate(Vector3.up, Time.deltaTime * 200);
		//transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 0.5F);
		}
		transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAtPlayer.rotation, 100*Time.deltaTime);

		if(wayPoint!=null && Vector3.Distance(transform.position, wayPoint.position)<= 0.1){
			//Destroy(wayPoint.gameObject);
			wayPoint = null;
		}
		//transform.LookAt(player);
	
	}

	void OnTriggerEnter(Collider collider){

		Companion otherAI = collider.gameObject.GetComponentInParent<Companion>();
		if(collider.gameObject.tag == "Enemy" /*&& wayPoint == null*/){
			float rightDis = Vector3.Distance(transform.position, otherAI.rightWayPoint.transform.position);
			float leftDis = Vector3.Distance(transform.position, otherAI.leftWayPoint.transform.position);
			if(rightDis < leftDis){
				rightStep = true;
				//wayPoint = otherAI.rightWayPoint.transform;
				//wayPoint = Instantiate(otherAI.rightWayPoint.transform, otherAI.rightWayPoint.transform.position, transform.rotation) as Transform;
			}else{
				leftStep = true;
				//wayPoint = otherAI.leftWayPoint.transform;
				//wayPoint = Instantiate(otherAI.leftWayPoint.transform, otherAI.leftWayPoint.transform.position, transform.rotation) as Transform;
			}
		}

	}

}
