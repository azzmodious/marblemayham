using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCtrl : MonoBehaviour {
	public GameObject targetGameObject; 
	private Text text; 
	public PlayerCtrl player = null;  
	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		player = GameObject.Find ("Player").GetComponent<PlayerCtrl>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null)
			text.text = "Score: " + player.score;
	}
}
