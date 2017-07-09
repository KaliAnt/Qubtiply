using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	Text sent;
	//Score s = new Score();
	// Use this for initialization
	void Update () {
		//GameObject.Find ("Score").guiText.guiText = s.getScore ();
		sent = GetComponent<Text>();
		if(SendData.sent) sent.text = "SENT!";
	}
}
