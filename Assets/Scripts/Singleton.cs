using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {
	

		public double latitud { get; set; }
		public double longitud { get; set; }

		private static Singleton instance;

		private Singleton() {
		double latitud = 10.10;
		double longitud = 10.10;
		}
		public static Singleton GetInstance() {
			if (instance == null) {
				instance = new Singleton();
			}
			return instance;
		}

	//	public void IncrementCont(){
	//		ContBalls ++;
	//	}

}



