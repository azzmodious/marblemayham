using UnityEngine;
using System.Collections;
public enum PickUpState{
	Alive, 
	BeingPickedUp
}
public class PickupCtrl : MonoBehaviour {
	private AudioSource pickUpAudio;

	private PickUpState state;
	private float rotAccel = 20;
	private float rotVel = 180;
	private float duration = 3.0f;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		pickUpAudio = GetComponentInParent<AudioSource> ();
		state = PickUpState.Alive;
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case PickUpState.Alive:
			whileAlive ();
			break;
		case PickUpState.BeingPickedUp:
			whileBeingPickedUp();
			break;
		}

	}
	private void whileAlive(){
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}

	private void whileBeingPickedUp(){
		rotVel += rotAccel;
		//transform.Rotate (new Vector3 (0, rotVel, 0) * Time.deltaTime);

	}
	public void onPickUp(){
		pickUpAudio.Play ();
		state = PickUpState.BeingPickedUp;
		Hashtable t = new Hashtable ();
		//t ["a"] = 0.0f;
		//t ["delay"] = 1.0f;
		//t ["time"] = 3;
		//t ["onComplete"] = "kill"; 
		t.Add ("alpha", 0.0);
		t.Add ("delay", 0.0);
		t.Add ("time", 3);
		//Color c = renderer.material.GetColor ("_Color");
		//renderer.material.SetColor("_Color", new Color(c.r, c.g, c.b, 0.5f));
		//iTween.FadeTo(gameObject,iTween.Hash("alpha", 0, "time", 3, "delay", 1));
		//iTween.FadeTo(gameObject, t);
		//iTween.MoveTo(gameObject, Vector3(0,0,0), 3);

		//gameObject.SetActive (false);
		/*iTween.MoveBy(gameObject, iTween.Hash("z", 3.0f, 
			"easeType", "easeInOutExpo", 
			"loopType", "pingPong",
			"islocal", true,
			"delay", .1));*/
		//iTween.MoveTo (gameObject, new Vector3 (transform.position.x, transform.position.y+5, transform.position.z), 2.0f);
		iTween.FadeTo (gameObject, 0.0f, 1.0f);
		gameObject.SetActive (false);

	}

	public void kill(){
		Debug.Log ("killed");		
	}

	
}
