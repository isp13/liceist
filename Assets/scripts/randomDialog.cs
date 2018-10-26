using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomDialog : MonoBehaviour {
	public int hoursStart;
	public int minutesStart;
	public int hoursEnd;
	public int minutesEnd;


	public string displaysentence;

	private int currtime;
	private int plantime1;
	private int plantime2;
	public TextMesh a;
	// Use this for initialization
	void Start () {
		TextMesh a=GetComponent<TextMesh>();
		plantime1 = hoursStart * 100 + minutesStart;
		plantime2 = hoursEnd * 100 + minutesEnd;
		
	}
	
	// Update is called once per frame
	void Update () {

		currtime = PlayerPrefs.GetInt ("hours") * 100 + PlayerPrefs.GetInt ("minutes");

		if (currtime >= plantime1 && currtime <= plantime2)
			a.text = displaysentence;
		else
			a.text = "";
	}
}
