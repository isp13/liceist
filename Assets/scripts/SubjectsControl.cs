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

		if (!PlayerPrefs.HasKey ("lesson1")) {
			PlayerPrefs.SetInt ("dayscount", 1);//days
			PlayerPrefs.SetInt ("lesson1", 0);//9:00-10:25
			PlayerPrefs.SetInt ("lesson2", 0);//10:45-12:10
			PlayerPrefs.SetInt ("lesson3", 0);//12:20-13:45
			PlayerPrefs.SetInt ("lesson4", 0);//14:45-16:10
			PlayerPrefs.SetInt ("lesson5", 0);//16:20-17:45
			PlayerPrefs.SetInt ("visits", 0);

		}
		int k = PlayerPrefs.GetInt ("dayscount");
		days.text = "ЭЛЕКТРОННЫЙ ЖУРНАЛ. День "+k.ToString();
		subjectscount = Random.Range(2,6);
		PlayerPrefs.SetInt ("amountoflessons",subjectscount);
		PlayerPrefs.Save ();

		DayStart ();

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
		PlayerPrefs.SetInt ("needsnewday", 0);

		for (int i = 1; i <= subjectscount; i++) {
			sub = new subject ();
			sub.SubjectGenerate ();
			str = "lesson" + i.ToString();
			PlayerPrefs.SetInt (str, sub.getroom());
			if (i== 1)
				txt1.text = "9:00-10:25 "+(sub.getname()).ToString()+"\n"+" кабинет: "+(sub.getroom()).ToString();
			if (i== 2)
				txt2.text = "10:45-12:10 "+(sub.getname()).ToString()+"\n"+" кабинет: "+(sub.getroom()).ToString();
			if (i== 3)
				txt3.text = "12:20-13:45 "+(sub.getname()).ToString()+"\n"+" кабинет: "+(sub.getroom()).ToString();
			if (i== 4)
				txt4.text = "14:45-16:10 "+(sub.getname()).ToString()+"\n"+" кабинет: "+(sub.getroom()).ToString();
			if (i== 5)
				txt5.text = "16:20-17:45 "+(sub.getname()).ToString()+"\n"+" кабинет: "+(sub.getroom()).ToString();
			
		}
		Debug.Log ("SUBJECT GENERATE COMPLETED");


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


	string[] subjects = {"Математика- Бородина","Теория Познания- Максудова","Английский- Воронкова","Физика- Строганкова","Компьютерная Линглвистика- Хазова"  };
	int[] rooms = {209,203,201,211,307 };

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
}
