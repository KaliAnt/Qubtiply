using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specifications {
	string a ="CPU: " + SystemInfo.processorType;
	string b = "FREQ: "+ (SystemInfo.processorFrequency) + " MHz";
	string c = "RAM: " + (SystemInfo.systemMemorySize) + " MB";
	//string d = "GPU: " + SystemInfo.graphicsDeviceVendor + " ";
	string e = SystemInfo.graphicsDeviceName;
	//string f = SystemInfo.graphicsDeviceType;
	string g = "GPU RAM: " + (SystemInfo.graphicsMemorySize) + " MB";
	string id = SystemInfo.deviceUniqueIdentifier;

	public string getSpecifications() {
		return	a+"|"+b+"|"+c+"|"+e+"|"+g+"|" + " ";
	}

	public string getUniqueId(){
		return id;
	}

}
