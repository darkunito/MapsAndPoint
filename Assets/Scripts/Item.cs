using UnityEngine;
using System.Collections;
using System;

public class Item : MonoBehaviour {

    public double Lat;
    public double Long;
	private TextMesh tm1;
	public GameObject text1;
	private LocationInfo loc;

	// Use this for initialization
	void Start () {
		
		Singleton.GetInstance().longitud = loc.longitude;
		Singleton.GetInstance().latitud = loc.latitude;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		tm1 = text1.GetComponent<TextMesh> ();
		string infotext = "Latitud:" + loc.latitude + "Longitud:" + loc.longitude;
		tm1.text = infotext;
	}

}
