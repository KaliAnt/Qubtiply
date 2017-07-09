using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndingMenu  : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Website() {
		Application.OpenURL("http://qubtiply.azurewebsites.net/Home");
	}

	public void Help() {
		Debug.Log ("Help");
	}

	public void Quit() {
		Application.Quit();
	}

	public void Send() {
		(new SendData()).Initialize ();
	}
}
