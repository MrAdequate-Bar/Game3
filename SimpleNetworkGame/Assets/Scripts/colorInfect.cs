using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class colorInfect : NetworkBehaviour{
	[SyncVar]
	private int score = 0;
	Color colorMe = Color.red;
	Color colorHim = Color.blue;
	public Material mat;
	GameObject scoreManager;

	// Use this for initialization

	public override void OnStartLocalPlayer()
	{
		colorMe = GetComponent<MeshRenderer>().material.color = Color.blue;
		colorHim = GetComponent<MeshRenderer>().material.color = Color.red;
		gameObject.GetComponent<MeshRenderer> ().material.SetColor ("_ColorMe", colorMe);
		MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer child in children)
			if(child.name.CompareTo("RaceC_red_body") == 0)
				child.material = mat;
	}

	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void updateScores(){
		score += 10;
		GetComponent<playerUI> ().updateScore (score);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.CompareTag ("Tile")) {
			Color tileColor = collision.gameObject.GetComponent<MeshRenderer> ().material.color;
			if (!tileColor.Equals(colorMe)) {
				if (!tileColor.Equals (colorHim)) {
					collision.gameObject.GetComponent<MeshRenderer> ().material.SetColor ("_Color", colorMe);
					updateScores ();
				}
				/*
				 foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player")) {
						if () {
							score2 -= 10;
							p.gameObject.GetComponent<playerUI> ().updateScore (score2);
						}
					}
				 */
			} 
		}
	}
}
