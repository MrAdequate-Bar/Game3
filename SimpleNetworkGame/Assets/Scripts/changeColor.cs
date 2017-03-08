using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColor : MonoBehaviour {

	public Material material;
	Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}

	void OnTriggerEnter(Collider other){

		if(other.gameObject.name == "Player 1")
		{
			rend.material.color = Color.red;

		}
	}
}
