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
			Debug.Log ("TIME LOAD COMPLETED");
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
			yield return new WaitForSeconds(1f);


			PlayerPrefs.SetInt ("hours",hours);
			PlayerPrefs.SetInt ("minutes",minutes);
			if (hours==9 && minutes<=15 && PlayerPrefs.GetInt("amountoflessons")>=1)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson1"));
			if (hours==10 && minutes>=45 && minutes<=59 && PlayerPrefs.GetInt("amountoflessons")>=2)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson2"));
			if (hours==12 && minutes>=20 && minutes<=35 && PlayerPrefs.GetInt("amountoflessons")>=3)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson3"));
			if (hours==14 && minutes>=45 && PlayerPrefs.GetInt("amountoflessons")>=4)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson4"));
			if (hours==16 && minutes>=20 && minutes<=35 && PlayerPrefs.GetInt("amountoflessons")>=5)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson5"));
			PlayerPrefs.Save ();
		}
	}
}
