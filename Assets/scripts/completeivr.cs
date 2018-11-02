/*
 Контроль готовности исследовательской работы 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class completeivr : MonoBehaviour {
	public Text ivrtext; 

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("ivr") == false)
			PlayerPrefs.SetInt ("ivr", 0);
	}
	
	// Update is called once per frame
	void Update () {
		ivrtext.text="Готовность вашего ивр: "+(PlayerPrefs.GetInt("ivr")).ToString()+"%";
		
		
	}
}
