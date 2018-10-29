using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settings : MonoBehaviour {

	public void cleanupPrefs()
	{
		PlayerPrefs.DeleteAll();
		Debug.Log ("PlayerPrefs were cleaned");
	}


}
