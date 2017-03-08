using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

public class playerFallRespawn : NetworkBehaviour {
	private float distance = 100;
	private Vector3 position = new Vector3(0,0f,0f);

	// Use this for initialization
	void Start () {
		foreach (GameObject g in GameObject.FindGameObjectsWithTag("Respawn")) {
			if (Mathf.Pow (g.transform.position.x - transform.position.x, 2f) < distance)
				position = g.transform.position;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		if (transform.position.y < -10f) {
			transform.position = position;
			GetComponent<playerMovement> ().freezePlayer ();
		}
	}
}
