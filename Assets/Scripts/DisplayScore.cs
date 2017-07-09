using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
	Text score;
	Score s = new Score();
	// Use this for initialization
	void Start () {
		//GameObject.Find ("Score").guiText.guiText = s.getScore ();
		score = GetComponent<Text>();
		score.text = s.getScore().ToString();
	}


	
	// Update is called once per frame
	void Update () {
		//score = :
	}
}
