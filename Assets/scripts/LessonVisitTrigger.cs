using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonVisitTrigger : MonoBehaviour {

	[SerializeField] private int classID;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player") && PlayerPrefs.GetInt("CurrentClass")==classID  )
		{
			PlayerPrefs.SetInt ("visits", PlayerPrefs.GetInt("visits")+1);
		}
	}
}
