using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class playerMovement : NetworkBehaviour
{
	private bool freeze = false;
	public float freezeTime = 2;
	private float unfreezeTime;
	private MeshRenderer carBody;
	private GameObject camera;
	public float horzSpeed = 50f;
	public float verSpeed = 15f;
	public bool speedPickup = false;
	public float gravity = 50f;
	private SphereCollider carCollider;

	public override void OnStartLocalPlayer()
	{
		MeshRenderer[] children = GetComponentsInChildren<MeshRenderer>();
		foreach (MeshRenderer child in children) 
			if (child.name.CompareTo ("RaceC_red_body") == 0)
				carBody = child;
		SphereCollider[] boxes = GetComponentsInChildren<SphereCollider>();
		foreach (SphereCollider box in boxes)
			if (box.name.CompareTo ("Cube") == 0)
				carCollider = box;

		camera = GameObject.FindGameObjectWithTag ("MainCamera");
		camera.transform.parent = transform;
		camera.transform.localPosition = new Vector3 (0f, 30f, -30f);
		camera.transform.localEulerAngles = new Vector3(135f, 180f, 180f);
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}
		if (freeze && Time.time >= unfreezeTime)
		{ 
			freeze = false;
		}
		if(!freeze){
			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * horzSpeed;;
			var z = Input.GetAxis("Vertical") * verSpeed;

			transform.Rotate(0, x, 0);
			GetComponent<Rigidbody> ().AddForce (transform.forward * z);
			//transform.Translate(0, 0, z);
		}
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			GetComponent<Rigidbody>().AddForce(Vector3.down*gravity);
			carCollider.material.bounciness = 0f;
		} 
		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			carCollider.material.bounciness = 0.5f;
		} 
	}

	public void freezePlayer(){
		freeze = true;
		unfreezeTime = Time.time + freezeTime;
		GetComponent<Rigidbody> ().velocity = Vector3.zero;
		GetComponent<Rigidbody> ().angularVelocity = Vector3.zero;

		StartCoroutine(Blink(2f));

	}

	IEnumerator Blink(float waitTime){
		float endTime = Time.time + waitTime;
		while(Time.time < endTime){
			carBody.enabled = false;
			yield return new WaitForSeconds (0.2f);
			carBody.enabled = true;
			yield return new WaitForSeconds(0.2f);
		}
	}
}