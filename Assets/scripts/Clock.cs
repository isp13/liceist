using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
	public Text TimeText;

	public int hours;
	public int minutes;


	 
	void Start () {
		if (!PlayerPrefs.HasKey ("hours")) {


			hours = 8;
			minutes = 30;
			PlayerPrefs.SetInt ("hours", hours);
			PlayerPrefs.SetInt ("minutes", minutes);
		} 
		else {
			hours = PlayerPrefs.GetInt("hours");
			minutes = PlayerPrefs.GetInt("minutes");
			Debug.Log ("TIME LOAD COMPLETED");
		}


		StartCoroutine(TestCoroutine());
	}
	
	// Update is called once per frame
	void Update () {

	


	}


	IEnumerator TestCoroutine()
	{
		while(true)
		{
			TimeText.text = "";
			minutes++;
			if (minutes == 60) {
				minutes = 0;
				hours++;
			}

			TimeText.text = hours+":";
			if (minutes < 10)
				TimeText.text += 0;
			TimeText.text += minutes;
			yield return new WaitForSeconds(5f);


			PlayerPrefs.SetInt ("hours",hours);
			PlayerPrefs.SetInt ("minutes",minutes);
			PlayerPrefs.Save ();
		}
	}
}
