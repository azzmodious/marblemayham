using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeCtrl : MonoBehaviour {
	private Text text; 
	// Use this for initialization
	void Start () {
		iTween.FadeTo (gameObject, 0.0f, 3.0f);
		text = GetComponent<Text> ();
		text.CrossFadeAlpha (0, 4, true);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
