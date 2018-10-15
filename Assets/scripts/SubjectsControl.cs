using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SubjectsControl : MonoBehaviour {
	public int subjectscount;
	public subject sub;
	string str;
	public Text txt1;
	public Text txt2;
	public Text txt3;
	public Text txt4;
	public Text txt5;
	public Text days;
	public GameObject EndingPanel;
	// Use this for initialization
	void Start () {
		

		PlayerPrefs.SetInt("wasitvisited",0);

		if (!PlayerPrefs.HasKey ("lesson1")) {
			PlayerPrefs.SetInt ("dayscount", 1);//days
			PlayerPrefs.SetInt ("lesson1", 0);//9:00-10:25
			PlayerPrefs.SetInt ("lesson2", 0);//10:45-12:10
			PlayerPrefs.SetInt ("lesson3", 0);//12:20-13:45
			PlayerPrefs.SetInt ("lesson4", 0);//14:45-16:10
			PlayerPrefs.SetInt ("lesson5", 0);//16:20-17:45
			PlayerPrefs.SetInt ("visits", 0);
			subjectscount = Random.Range(2,6);
			PlayerPrefs.SetInt ("amountoflessons",subjectscount);
			PlayerPrefs.Save ();

		}

		subjectscount = PlayerPrefs.GetInt ("amountoflessons");
		int k = PlayerPrefs.GetInt ("dayscount");
		days.text = "ЭЛЕКТРОННЫЙ ЖУРНАЛ. День "+k.ToString();

		Debug.Log (subjectscount);

		if (PlayerPrefs.GetInt ("lesson1") == 0 || 1==1)//fix error with regenerating but not generating
			DayStart ();
		else {
			ContinueDay ();
		}

	}
	public void cleanuptext()
	{
		txt1.text = " ";
		txt2.text = " ";
		txt3.text = " ";
		txt4.text = " ";
		txt5.text = " ";
	}
	// Update is called once per frame
	void Update () {
		
	}
	public int getnumofclasses()
	{
		return subjectscount;
	}

	public void DayStart()
	{
		cleanuptext();
		PlayerPrefs.SetInt ("needsnewday", 0);

		for (int i = 1; i <= subjectscount; i++) {
			sub = new subject ();
			sub.SubjectGenerate ();
			str = "lesson" + i.ToString();
			PlayerPrefs.SetInt (str, sub.getroom());
			if (i== 1)
				txt1.text = "9:00-10:25 "+(sub.getname()).ToString()+" кб:"+(sub.getroom()).ToString();
			if (i== 2)
				txt2.text = "10:45-12:10 "+(sub.getname()).ToString()+" кб:"+(sub.getroom()).ToString();
			if (i== 3)
				txt3.text = "12:20-13:45 "+(sub.getname()).ToString()+" кб:"+(sub.getroom()).ToString();
			if (i== 4)
				txt4.text = "14:45-16:10 "+(sub.getname()).ToString()+" кб:"+(sub.getroom()).ToString();
			if (i== 5)
				txt5.text = "16:20-17:45 "+(sub.getname()).ToString()+" кб:"+(sub.getroom()).ToString();
			
		}
		Debug.Log ("SUBJECT GENERATE COMPLETED");


	}

	public void ContinueDay()
	{
		Debug.Log ("Day continue");
		sub = new subject ();
		for (int i = 1; i <= subjectscount; i++) {
			str = "lesson" + i.ToString();
			int lessonid = PlayerPrefs.GetInt (str);
			string lessonname="";

			for (int j=0; j<sub.massivecount(); j++)
			{
				if (sub.rooms [j] == lessonid)
					lessonname = sub.subjects [j];
			}


			if (i== 1)
				txt1.text = "9:00-10:25 "+lessonname+" кб:"+(lessonid).ToString();
			if (i== 2)
				txt2.text = "10:45-12:10 "+lessonname+" кб:"+(lessonid).ToString();
			if (i== 3)
				txt3.text = "12:20-13:45 "+lessonname+" кб:"+(lessonid).ToString();
			if (i== 4)
				txt4.text = "14:45-16:10 "+lessonname+" кб:"+(lessonid).ToString();
			if (i== 5)
				txt5.text = "16:20-17:45 "+lessonname+" кб:"+(lessonid).ToString();

		}
		Debug.Log ("SUBJECT reGENERATE COMPLETED");
	}

	public void DayEnd()
	{
		PlayerPrefs.SetInt ("visits", 0);
		PlayerPrefs.SetInt ("IQ", PlayerPrefs.GetInt("IQ")-2);
		PlayerPrefs.SetInt ("hours", 8);
		PlayerPrefs.SetInt ("minutes", 30);
		PlayerPrefs.SetInt ("dayscount", PlayerPrefs.GetInt("dayscount")+1);
		PlayerPrefs.SetInt ("lesson1", 0);//9:00-10:25
		PlayerPrefs.SetInt ("lesson2", 0);//10:45-12:10
		PlayerPrefs.SetInt ("lesson3", 0);//12:20-13:45
		PlayerPrefs.SetInt ("lesson4", 0);//14:45-16:10
		PlayerPrefs.SetInt ("lesson5", 0);//16:20-17:45
		PlayerPrefs.Save();
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


	public string[] subjects = {"Математика","Теория Познания","Английский","Физика","Комп.Линглвистика"  };
	public int[] rooms = {208,203,201,209,307 };

	public void SubjectGenerate()
	{

		tmp=Random.Range(0,subjects.Length);
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
	public int massivecount()
	{
	return subjects.Length;
	}

}
