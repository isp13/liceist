using System.Collections;
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

	public Text mark1;
	public Text mark2;
	public Text mark3;
	public Text mark4;
	public Text mark5;

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
				Debug.Log("amount: "+PlayerPrefs.GetInt ("amountoflessons") );
				Debug.Log("visits: "+PlayerPrefs.GetInt ("visits") );
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
			yield return new WaitForSeconds(1f);//время в игре


			PlayerPrefs.SetInt ("hours",hours);
			PlayerPrefs.SetInt ("minutes",minutes);
			if (hours==9 && minutes<=15 && PlayerPrefs.GetInt("amountoflessons")>=1)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson1"));
			if (hours==10 && minutes>=45 && minutes<=59 && PlayerPrefs.GetInt("amountoflessons")>=2)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson2"));
			if (hours==12 && minutes>=20 && minutes<=35 && PlayerPrefs.GetInt("amountoflessons")>=3)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson3"));
			if (hours==14 && minutes>=45 && minutes<=59 && PlayerPrefs.GetInt("amountoflessons")>=4)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson4"));
			if (hours==16 && minutes>=20 && minutes<=35 && PlayerPrefs.GetInt("amountoflessons")>=5)PlayerPrefs.SetInt ("CurrentClass", PlayerPrefs.GetInt("lesson5"));

			//mark
			if (hours==10 && minutes==25 && PlayerPrefs.GetInt("amountoflessons")>=1)
			{
				if (PlayerPrefs.GetInt("wasitvisited")==1)
				{
					PlayerPrefs.SetInt("wasitvisited",0);
					mark1.text="5";
				}
				else
				{
					mark1.text="H";
				}
			}
			if (hours==12 && minutes==10 && PlayerPrefs.GetInt("amountoflessons")>=2)
			{
				if (PlayerPrefs.GetInt("wasitvisited")==1)
				{
					PlayerPrefs.SetInt("wasitvisited",0);
					mark2.text="5";
				}
				else
				{
					mark2.text="H";
				}

			}

			if (hours==13 && minutes==45 && PlayerPrefs.GetInt("amountoflessons")>=3)
			{
				if (PlayerPrefs.GetInt("wasitvisited")==1)
				{
					PlayerPrefs.SetInt("wasitvisited",0);
					mark3.text="5";
				}
				else
				{
					mark3.text="H";
				}
			}
			if (hours==16 && minutes==10 && PlayerPrefs.GetInt("amountoflessons")>=4)
			{
				if (PlayerPrefs.GetInt("wasitvisited")==1)
				{
					PlayerPrefs.SetInt("wasitvisited",0);
					mark4.text="5";
				}
				else
				{
					mark4.text="H";
				}
			}
			if (hours==17 && minutes==45 && PlayerPrefs.GetInt("amountoflessons")>=5)
			{
				if (PlayerPrefs.GetInt("wasitvisited")==1)
				{
					PlayerPrefs.SetInt("wasitvisited",0);
					mark5.text="5";
				}
				else
				{
					mark5.text="H";
				}
			}
			PlayerPrefs.Save ();
		}
	}
}
