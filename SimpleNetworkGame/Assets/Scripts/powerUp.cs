using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class powerUp : NetworkBehaviour {
	public GameObject player;
	public GameObject pickup;
	public playerMovement p1;
	public powerUpManager power;
	public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Player"){
			player = other.gameObject;
			p1 = player.GetComponent<playerMovement> ();
			if (!p1.speedPickup) { //This should fix the multiple pickups causing permanent speed increases
				p1.horzSpeed *= 2;
				p1.verSpeed *= 2;
				p1.speedPickup = true;
				power.p1 = p1;
			}
			power.timer = 5f; // Extra pickups restart timer
			power.pickupTimer = true;
			Destroy (gameObject);

			int spawnPointIndex = Random.Range (0, spawnPoints.Length);

			Instantiate (pickup, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			//Physics.IgnoreCollision (other.gameObject.GetComponent<BoxCollider>(), GetComponent<BoxCollider> ());
		}
	}
}
