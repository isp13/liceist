using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LessonVisitTrigger : MonoBehaviour {

	[SerializeField] private int classID;

	public Button bttn;



	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player") && PlayerPrefs.GetInt("CurrentClass")==classID && PlayerPrefs.GetInt("wasitvisited")!=1 )
		{
			bttn.onClick.Invoke ();
			PlayerPrefs.SetInt("visits", PlayerPrefs.GetInt("visits")+1);
			PlayerPrefs.SetInt("wasitvisited",1);
			int iqcounter=PlayerPrefs.GetInt ("IQ");
			PlayerPrefs.SetInt ("IQ", iqcounter+2);
			Debug.Log("урок посещен");
		}
		
	}
}
