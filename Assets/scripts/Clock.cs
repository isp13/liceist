﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
	public Text TimeText;
	public Text iqtext;
	public int hours;
	public int minutes;
	public GameObject dialogCan;
	public GameObject LifeIQCan;
	public GameObject TimeCan;
	public GameObject sheduleCan;
	public GameObject DayEndingCan;
	public Text daynum;
	public Text freelessons;
	public Text scores;

	private int startedwithiq;

	 
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

	public void settime(int h,int m)
	{
		hours = h;
		minutes = m;
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
			if (hours==9 && minutes==0)
				startedwithiq=PlayerPrefs.GetInt("IQ");
			if(hours>=20)
			{
				PlayerPrefs.SetInt ("needsnewday", 1);
				dialogCan.SetActive (false);
				sheduleCan.SetActive (false);
				LifeIQCan.SetActive (false);
				TimeCan.SetActive (false);
				int k = PlayerPrefs.GetInt ("dayscount");
				daynum.text = "ДЕНЬ "+k.ToString();
				int lessloss = PlayerPrefs.GetInt ("amountoflessons") - PlayerPrefs.GetInt ("visits");
				int iqlost=PlayerPrefs.GetInt("IQ")-startedwithiq;
				iqtext.text="IQ заработано: "+iqlost.ToString();
				freelessons.text="Пар пропущено: "+lessloss.ToString();
				int scorescount=100+iqlost+lessloss;
				scores.text="Очков получено: "+scorescount.ToString();
				DayEndingCan.SetActive (true);

				//yield break;
			}

			TimeText.text = hours+":";
			if (minutes < 10)
				TimeText.text += 0;
			TimeText.text += minutes;
			yield return new WaitForSeconds(0.01f);//время в игре


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
