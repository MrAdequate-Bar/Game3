using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class GameStatus : NetworkBehaviour {
	private float _oldWidth;
	private float _oldHeight;
	private float _fontSize = 16f;
	private float Ratio = 20f;
	public GameObject player;
	public colorInfect win;
	public Text winText;
	public Text restartText;
	float timeLeft = 1.0f;
	bool displayScores = false;

	void Awake(){
		AudioSource[] allAudioSources =
			UnityEngine.Object.FindObjectsOfType<AudioSource>();
		foreach (AudioSource a in allAudioSources)
			a.Stop ();
		GetComponent<AudioSource> ().Play ();
		restartText.enabled = false;
	}

	void Start(){

	}

	void Update()
	{
		timeLeft -= Time.deltaTime;
		if(timeLeft < 0)
		{
			GameOver();
			Restart ();

		}
		//Code from https://forum.unity3d.com/threads/changing-text-size-relative-to-screen.102876/
		if (_oldWidth != Screen.width || _oldHeight != Screen.height) {
			_oldWidth = Screen.width;
			_oldHeight = Screen.height;
			_fontSize = Mathf.Min(Screen.width, Screen.height) / Ratio;
		}
		// To here
	}
	void GameOver(){
		displayScores = true;
		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");
		GameObject winner = players[0];
		int highScore = -1;
		foreach (GameObject p in players) {
			if (highScore < p.GetComponent<playerUI> ().GetScore ()) {
				highScore = p.GetComponent<playerUI> ().GetScore ();
				winner = p;
				p.GetComponent<playerUI> ().gameOver = true;
			}
		}
		winner.GetComponent<playerUI> ().won = true;
	}

	void Restart(){
		restartText.enabled = true;
		restartText.text = "Press 'F1' to return to Start Menu";
		if (Input.GetKeyDown (KeyCode.F1)) {
			SceneManager.LoadScene("Menu");
		}
	}

	private void OnGUI()
	{
		if (displayScores) {
			GUI.skin.textField.fontSize = (int)_fontSize;
			//Draw Score on screen
			GUI.TextField (ResizeGUI (new Rect (250, 10, 120, 20)), "GameOver! ");

		} else {
			GUI.skin.textField.fontSize = (int)_fontSize;
			//Draw Score on screen
			GUI.TextField (ResizeGUI (new Rect (250, 10, 120, 20)), "Time: " + timeLeft.ToString ());
		}
	}
	//Code From http://answers.unity3d.com/questions/307330/gui-scale-guis-according-to-resolution.html
	Rect ResizeGUI(Rect _rect)
	{
		float FilScreenWidth = _rect.width / 400;
		float rectWidth = FilScreenWidth * Screen.width;
		float FilScreenHeight = _rect.height / 300;
		float rectHeight = FilScreenHeight * Screen.height;
		float rectX = (_rect.x / 400) * Screen.width;
		float rectY = (_rect.y / 300) * Screen.height;

		return new Rect(rectX,rectY,rectWidth,rectHeight);
	}
	// To here
}
