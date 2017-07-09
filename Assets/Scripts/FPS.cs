using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour
{
	public static  float maxFPS = 0.0f;
	public static float middleFPS = 60.0f;
	float deltaTime = 0.0f;
	float msec;
	float fps;

	void Update()
	{
		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		msec = deltaTime * 1000.0f;
		fps = 1.0f / deltaTime;
		if (maxFPS < fps) {
			maxFPS = fps;
		}
		middleFPS = (middleFPS+fps)/2;
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(-10, 10, w, h * 2 / 60);
		style.alignment = TextAnchor.UpperRight;
		style.fontSize = h * 2 / 60;
		style.normal.textColor = new Color (255f, 255f, 255f, 1.0f);
		string text = string.Format("{1:0.} fps", msec, fps);
		GUI.Label(rect, text, style);
	}
}