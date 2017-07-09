using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayGrade : MonoBehaviour {

	Text grade;
	Score s = new Score();
	// Use this for initialization
	void Start () {
		//GameObject.Find ("Score").guiText.guiText = s.getScore ();
		grade = GetComponent<Text>();
		grade.text = s.getGrade().ToString() + "/10";
	}



	// Update is called once per frame
	void Update () {
		
	}
}
