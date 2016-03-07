using UnityEngine;
using System.Collections;

public delegate void PlayerCollisionHandler(GameObject player, Collider other);
public class GameCtrl : MonoBehaviour {

	private static GameCtrl gameCtrl; 

	public static event PlayerCollisionHandler onPlayerCollision; 
	private static GameCtrl instance{
		get{
			if (!gameCtrl) {
				gameCtrl = FindObjectOfType (typeof(GameCtrl)) as GameCtrl;

				if (!gameCtrl) {
					Debug.LogError ("There needs to be an active GameCtrl script on a game object");
				} else {
					gameCtrl.Init();
				}
			}
			return gameCtrl;
		}
	}

	void Init(){
		onPlayerCollision += handlePlayerCollision;
	
	}

	public static void TriggerPlayerCollisionEvent(GameObject player, Collider other){
		onPlayerCollision(player, other);
	}

	private void handlePlayerCollision(GameObject player, Collider other){
		if (other.gameObject.CompareTag ("pickup")) {
			
			PickupCtrl pickupCtrl = other.gameObject.GetComponent<PickupCtrl> ();
			pickupCtrl.onPickUp();
			PlayerCtrl playerCtrl = player.GetComponent<PlayerCtrl> ();
			playerCtrl.score += 100;

		}

		if (other.gameObject.CompareTag ("pit")) {
			PlayerCtrl playerCtrl = player.GetComponent<PlayerCtrl> ();
			playerCtrl.Respawn(playerCtrl.SpawnPoint);
			playerCtrl.lives -= 1;


		}

		if (other.gameObject.CompareTag ("goal")) {
			PlayerCtrl playerCtrl = player.GetComponent<PlayerCtrl> ();
			playerCtrl.Respawn(playerCtrl.SpawnPoint);
		}

	}
	// Use this 		for initialization
	void Start () {
		GameCtrl.instance.Init ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
