using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LIFEandIQ : MonoBehaviour {
	public GameObject heart1;
	public GameObject heart2;
	public GameObject heart3;
	public Text IQText;
	public int iqcount;
	public int hearts;
	// Use this for initialization
	void Start () {
		heart1.SetActive (false);
		heart2.SetActive (false);
		heart3.SetActive (false);
		if (!PlayerPrefs.HasKey ("life")) {
			hearts = 3;
			PlayerPrefs.SetInt ("life", hearts);
		} 
		else {
			hearts = PlayerPrefs.GetInt("life");
			Debug.Log ("LIFE LOAD COMPLETED");
		}

		for (int i = 1; i <= hearts; i++) {
			if (i == 1) {
				heart1.SetActive (true);
			}
			if (i == 2) {
				heart2.SetActive (true);
			}
			if (i == 3) {
				heart3.SetActive (true);
			}
		}




		if (!PlayerPrefs.HasKey ("IQ")) {
			iqcount = 10;
			PlayerPrefs.SetInt ("IQ", iqcount);
		} else {
			iqcount = PlayerPrefs.GetInt("IQ");
			Debug.Log ("IQ LOAD COMPLETED");
		}

		IQText.text = ""+iqcount+"/100";


	}
	public int getiq()
	{
		return iqcount;
	}
	// Update is called once per frame
	void Update () {
		iqcount=PlayerPrefs.GetInt("IQ");
		IQText.text = ""+iqcount+"/100";
	}

}
