using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletFireP2 : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed = 5.0f;
	// Use this for initialization

	void Update(){
		if (Input.GetKeyDown (KeyCode.RightControl)) {
			GameObject thebullet = (GameObject)Instantiate (bullet, transform.position, transform.rotation);
			thebullet.GetComponent<Rigidbody> ().AddForce (transform.forward * bulletSpeed, ForceMode.Impulse);
		}
	}
}
