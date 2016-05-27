using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetWWW : MonoBehaviour {
	
	public Text location_field;
	public Text description_field;

	string point_url = "http://direccio-ip:port/codi.pl";

	LocationInfo loc;

	// Use this for initialization
	IEnumerator Start () {
		string locationName = location_field.text.ToString();
		string description = description_field.text.ToString();
		string longit = System.Convert.ToString (Singleton.GetInstance ().longitud);
		string latit = System.Convert.ToString (Singleton.GetInstance ().latitud);
		// Create a form object for sending point data to the server
		WWWForm form = new WWWForm();
		// The name of the point
		form.AddField( "Location Name:", locationName );
		// The description of the point
		form.AddField( "Description:", description );
		// The location
		form.AddField ("longitud:", longit);
		form.AddField ("latitud:", latit);

		// Create a download object
		WWW download = new WWW( point_url, form );

		// Wait until the download is done
		yield return download;

		if(!string.IsNullOrEmpty(download.error)) {
			print( "Error downloading: " + download.error );
		} else {
			// show the saved point
			Debug.Log(download.text);
		}
	}
}
