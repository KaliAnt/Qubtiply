using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	private static string lastScene = "";

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void AboutStart() {
		lastScene = "StartMenu";
		SceneManager.LoadScene ("About");
	}

	public void AboutEnd() {
		lastScene = "EndMenu";
		SceneManager.LoadScene ("About");
	}

	public void Back() {
		SceneManager.LoadScene (lastScene);
	}

	public void ContinueEnd() {
		SceneManager.LoadScene ("EndMenu");
	}

	public void WebSite() {
		Application.OpenURL("http://qubtiply.azurewebsites.net/Home");
	}

	public void Send() {
		(new SendData()).Initialize ();
	}

	public void StartGame() {
		SceneManager.LoadScene("Fractal");
	}

	public void Quit() {
		Application.Quit();
	}
}