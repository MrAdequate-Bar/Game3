using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class powerUpManager : NetworkBehaviour {
	public bool pickupTimer = false;
	public float timer = 5f;
	public playerMovement p1;


	// Update is called once per frame
	void Update () {
		if (pickupTimer) {
			timer -= Time.deltaTime;

			if (timer <= 0) {
				p1.horzSpeed /= 2;
				p1.verSpeed /= 2;
				p1.speedPickup = false;
				timer = 5f;
				pickupTimer = false;
			}
		}
	}
}
