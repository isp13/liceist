using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LessonVisitTrigger : MonoBehaviour {

	[SerializeField] private int classID;

	public Button TEORP;
	public Button MATH;
	public Button INFA;
	public Button RUSS;
	public Button PHYSC;
	public Button LITER;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player") && PlayerPrefs.GetInt("CurrentClass")==classID && PlayerPrefs.GetInt("wasitvisited")!=1 )
		{
			PlayerPrefs.SetInt("visits", PlayerPrefs.GetInt("visits")+1);
			PlayerPrefs.SetInt("wasitvisited",1);
			int iqcounter=PlayerPrefs.GetInt ("IQ");
			PlayerPrefs.SetInt ("IQ", iqcounter+2);
			Debug.Log("урок посещен");

			if (classID==203)
				TEORP.onClick.Invoke ();
			if (classID == 205)
				MATH.onClick.Invoke ();
			if (classID == 307 || classID == 208 || classID == 207 || classID==501)
				INFA.onClick.Invoke ();
			if (classID == 301)
				RUSS.onClick.Invoke ();
			if (classID == 209)
				PHYSC.onClick.Invoke ();
			if (classID == 403)
				LITER.onClick.Invoke ();
			
				
				
				

		}
		
	}
}
