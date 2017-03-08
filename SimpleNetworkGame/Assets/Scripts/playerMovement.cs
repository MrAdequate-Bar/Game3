using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerMovement : NetworkBehaviour
{
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * 30.0f;

		transform.Rotate(0, x, 0);
		GetComponent<Rigidbody> ().AddForce (transform.forward * z);
		//transform.Translate(0, 0, z);
	}
}