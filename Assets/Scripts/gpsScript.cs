using UnityEngine;
using System.Collections;

public class gpsScript : MonoBehaviour {

	int maxWait;

	public float longUsu { get; set; }

	public float latUsu { get; set;}

	// Use this for initialization
	IEnumerator  Start () {
		
		if(!Input.location.isEnabledByUser)
			yield break;

		Input.location.Start(10.0f,10.0f);
		maxWait = 20;
		while(Input.location.status == LocationServiceStatus.Initializing && maxWait>0){
			yield return new WaitForSeconds(1);
			maxWait = maxWait-1;
		}

		if (maxWait<1){
			yield break;
		}
		if (Input.location.status == LocationServiceStatus.Failed){
			yield break;
		}
		//Input.location.Stop();
	}

	// Update is called once per frame
	void Update () {

		longUsu = Input.location.lastData.longitude;
		latUsu = Input.location.lastData.latitude;

	}


	float CalcDistance(float lon1, float lat1, float lon2, float lat2){
		int R = 6371; // radius of earth in km
		float dLat = (lat2-lat1)*(Mathf.PI / 180);
		float dLon = (lon2-lon1)*(Mathf.PI / 180);
		lat1 = lat1*(Mathf.PI / 180);
		lat2 = lat2*(Mathf.PI / 180);
		float a = Mathf.Sin(dLat/2) * Mathf.Sin(dLat/2) + Mathf.Sin(dLon/2) * Mathf.Sin(dLon/2) * Mathf.Cos(lat1) * Mathf.Cos(lat2); 
		float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1-a)); 
		float d = R * c;
		return d; //distance in kms
	}

}
