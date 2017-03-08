using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.Networking;

public class playerUI : NetworkBehaviour {
	private GameObject player;
	private int score;
	private string playerName = "Their";
	private int _scoreY = 60;

	private float _oldWidth;
	private float _oldHeight;
	private float _fontSize = 16f;
	private float Ratio = 20f;

	public override void OnStartLocalPlayer()
	{
		playerName = "My";
		_scoreY = 30;
	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		//Code from https://forum.unity3d.com/threads/changing-text-size-relative-to-screen.102876/
		if (_oldWidth != Screen.width || _oldHeight != Screen.height) {
			_oldWidth = Screen.width;
			_oldHeight = Screen.height;
			_fontSize = Mathf.Min(Screen.width, Screen.height) / Ratio;
		}
		// To here
	}

	private void OnGUI()
	{
			GUI.skin.textField.fontSize = (int) _fontSize;
			//Draw Score on screen
			GUI.TextField (ResizeGUI(new Rect (250, _scoreY, 120, 20)), playerName + " Score: " + score.ToString ());
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
	public void updateScore(int newScore)
	{
		score = newScore;
	}
}
