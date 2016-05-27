using UnityEngine;
using System.Collections;
using System;

public class Item : MonoBehaviour {

    public double Lat;
    public double Long;
	private TextMesh tm1;
	public GameObject text1;

	public GameObject gps;
	private LocationInfo loc;

	// Use this for initialization
	void Start () {
		gps = GameObject.FindGameObjectWithTag ("gps");

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		tm1 = text1.GetComponent<TextMesh> ();
		string infotext = "Latitud:" + gps.GetComponent<gpsScript>().latUsu + "Longitud:" + gps.GetComponent<gpsScript>().longUsu ;
		tm1.text = infotext;
	}

}
