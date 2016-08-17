using UnityEngine;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	public Transform player;
	public Transform ojectToFollow;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = ojectToFollow.position;
		transform.LookAt(player);
	}
}
