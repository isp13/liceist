using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SubjectsControl : MonoBehaviour {
	public int subjectscount;
	public subject sub;
	// Use this for initialization
	void Start () {

		if (!PlayerPrefs.HasKey ("lesson1")) {
			PlayerPrefs.SetInt ("lesson1", 0);//9:00-10:25
			PlayerPrefs.SetInt ("lesson2", 0);//10:45-12:10
			PlayerPrefs.SetInt ("lesson3", 0);//12:20-13:45
			PlayerPrefs.SetInt ("lesson4", 0);//14:45-16:10
			PlayerPrefs.SetInt ("lesson5", 0);//16:20-17:45
		}
		subjectscount = Random.Range(2,6);
		DayStart();



	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void DayStart()
	{
		//sub = new subject ();
		//sub.SubjectGenerate ();
		//PlayerPrefs.SetInt ("lesson1", sub.room);
		for (int i = 1; i <= subjectscount; i++) {
			sub = new subject ();
			sub.SubjectGenerate ();
			PlayerPrefs.SetInt ("lesson"+i, sub.getroom());
			Debug.Log (sub.getroom()+ " "+i);
		}

	}
		
}

public class subject {

	public string name;
	public int room;
	public int tmp;

	public subject()
	{
		name = "name";
		room = 0;
		tmp = 0;
	}


	string[] subjects = {"Математика- Бородина","Теория Познания- Максудова" };
	int[] rooms = {209,203 };

	public void SubjectGenerate()
	{

		tmp=Random.Range(0,2);
		name = subjects[tmp];
		room = rooms[tmp];

	}

	public string getname()
	{
		return name;
	}
	public int getroom()
	{
		return room;
	}
}
