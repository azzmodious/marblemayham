using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour {
	public int score; 
	public int lives;
	public float speed = 5.0f;
	private Rigidbody rb;
	private Vector3 spawnPoint; 
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		spawnPoint = transform.position;
		score = 0;
		lives = 3;
	}
	
	// Update is called once per frame
	void Update () {
		ProcessInput();
	}

	void ProcessInput(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		GameCtrl.TriggerPlayerCollisionEvent (gameObject, other);

	}


	/**
	 * Public Properties
	 */

	public Vector3 SpawnPoint{
		get{return spawnPoint;}
		set{spawnPoint = value;}
	}
	/**
	 * Public functions
	 **/

	/**
	* Warps the player to a new location and plays a spawning animation
	*/
	public void Respawn(Vector3 location){
		transform.position = location;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}




}
