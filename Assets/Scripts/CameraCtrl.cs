using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour {
	private GameObject player;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
