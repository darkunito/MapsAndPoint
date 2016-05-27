using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WWWFormImage : MonoBehaviour {

	public Text location_field;
	public Text description_field;

	public string point_url = "http://direccio-ip:port/codi.pl";


	LocationInfo loc;

	// Use this for initialization
	void Start () {
		StartCoroutine(UploadPointData());
	}

	IEnumerator UploadPointData() {
		
		string locationName = location_field.text.ToString();
		string description = description_field.text.ToString();
		// Create a Web Form
		// Create a form object for sending point data to the server
		WWWForm form = new WWWForm();
		// The name of the point
		form.AddField( "Location Name:", locationName );
		// The description of the point
		form.AddField( "Description:", description );
		// The location
		form.AddField ("longitud:", System.Convert.ToString(Singleton.GetInstance ().longitud));
		form.AddField ("latitud:", System.Convert.ToString(Singleton.GetInstance ().latitud));

		// Upload to a cgi script
		WWW w = new WWW(point_url, form);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			print(w.error);
		}
		else {
			print("Finished Uploading");
		}
	}
}