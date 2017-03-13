using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class bulletFireP1 : NetworkBehaviour {
	public GameObject bullet;
	public GameObject player;
	public playerMovement enemy;
	public float bulletSpeed = 5.0f;
	// Use this for initialization
		
	void Update(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject thebullet = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
			thebullet.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {
			player = other.gameObject;
			enemy = player.GetComponent<playerMovement> ();
			enemy.horzSpeed /= 2;
			enemy.verSpeed /= 2;

		}
	}
}