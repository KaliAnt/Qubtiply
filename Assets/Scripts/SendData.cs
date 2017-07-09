using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;
using System.Net;
//using System.Runtime.Serialization.Configura;
using System.Text;
//using JsonUtility.ToJson;

public class SendData {

	public static bool sent = false;
	// Use this for initialization
	public void Initialize () {
		Data data = new Data();
		Specifications spec = new Specifications();

		data.UniqueId = spec.getUniqueId();
		data.Score = Fractal.Frames+NucleonSpawner.Frames+StuffSpawner.Frames;
		data.Specifications = spec.getSpecifications();
		Debug.Log (data.Score);
		String json = JsonUtility.ToJson (data);
		Debug.Log (json);
		readHtmlPage("http://qubtiply.azurewebsites.net/Data/Create", json);
	}



	static String readHtmlPage(string url, string json)
	{

		//setup some variables


		//setup some variables end

		String result = "";
		String strPost = "json=" + json;
		//StreamWriter myWriter = new StreamWriter();

		HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);
		objRequest.Method = "POST";
		objRequest.ContentLength = strPost.Length;
		objRequest.ContentType = "application/x-www-form-urlencoded";

		try
		{
			StreamWriter myWriter = new StreamWriter(objRequest.GetRequestStream());
			myWriter.Write(strPost);
			myWriter.Close();
		}
		catch (Exception e)
		{
			Debug.Log ("I hate my life 2");
			return e.Message;
		}
		finally
		{
			Debug.Log ("I hate my life");
		}

		/*HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
		using (StreamReader sr =
			new StreamReader(objResponse.GetResponseStream()))
		{
			result = sr.ReadToEnd();

			// Close and clean up the StreamReader
			sr.Close();
		}*/
		sent = true;
		return result;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
	
public class Data
{
	public int DataID;

	public string UniqueId;
	public int Score;
	public string Specifications;

}
	