using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class questions : MonoBehaviour {
	public GameObject QuizCanvas;
	public GameObject npcs;
	public GameObject joy;
	public Text mainquetion;
	public Text bt1;
	public Text bt2;
	public Text bt3;
	public Text bt4;

	private string answers ="";
	public int mark=0;

	public quiz[] math=new quiz[10];
	public quiz[] info=new quiz[10];
	public quiz[] russ=new quiz[10];
	public quiz[] main=new quiz[10];

	void Start () {
		//MATH
		math [0] = new quiz (0,"Чему равно sin(30)+сos(2pi)-ctg(pi/4)+1/2","0","1","1/2","3/2",'2');
		math [1] = new quiz (1,"Что такое логарифм числа b по основанию a?","Показатель степени, в которую нужно возвести a, чтобы получить b","Показатель степени, в которую нужно возвести b, чтобы получить a","Число a в степени b","Не знаю",'1');
		math [2] = new quiz (2,"Укажите иррациональное число","2*2","234","17/18","sqrt(2)",'4');

		//INFORMATICS
		info [0] = new quiz (0,"Что такое массив?","Элемент базы данных","Переменная вида string","структура данных","Высокая часть горной местности",'3');
		info [1] = new quiz (1,"Чем является TCP?","основной протокол передачи данных в интернете","Маршрутизированный сетевой протокол, основа ip","Протокол пользовательских датаграмм","Интерфейс для связи устройств",'1');
		info [2] = new quiz (2,"Что такое html?","Язык программирования","Библиотека в с++","Язык сетевых взаимодействий","Стандартизированный язык разметки документов в Интернете",'4');


		//RUSSIAN LANGUAGE
		russ [0] = new quiz (0,"Выберите неверно выделенное ударение в слове","ненАдолго","Иксы","понялА","снятА",'1');
		russ [1] = new quiz (1,"Выберите неверно выделенное ударение в слове","рвалА","прибылА","налилА","клалА",'4');
		russ [2] = new quiz (2,"Выберите неверно выделенное ударение в слове","звонИшь","принЯвший","начАв","пОняв",'4');
		russ [3] = new quiz (0,"Выберите неверно выделенное ударение в слове","ненАдолго","Иксы","понялА","снятА",'1');
		russ [4] = new quiz (1,"Выберите неверно выделенное ударение в слове","рвалА","прибылА","налилА","клалА",'4');
		//PREPARED QUESTIONS
		main [0] = new quiz (0,"Выберите неверно выделенное ударение в слове","ненАдолго","Иксы","понялА","снятА",'1');
		main [1] = new quiz (1,"Выберите неверно выделенное ударение в слове","рвалА","прибылА","налилА","клалА",'4');
		main [2] = new quiz (2,"Выберите неверно выделенное ударение в слове","звонИшь","принЯвший","начАв","пОняв",'4');
		main [3] = new quiz (0,"Выберите неверно выделенное ударение в слове","ненАдолго","Иксы","понялА","снятА",'1');
		main [4] = new quiz (1,"Выберите неверно выделенное ударение в слове","рвалА","прибылА","налилА","клалА",'4');


	}

	public void Generate(string cls)
	{
		if (cls == "MATH") {
			for(int i=0;i<5;i++)
				main[i]=math[Random.Range(0,3)];
		
		}
		if (cls == "RUSS") {
			for(int i=0;i<5;i++)
				main[i]=russ[Random.Range(0,5)];

		}
		if (cls == "INFO") {
			for(int i=0;i<5;i++)
				main[i]=info[Random.Range(0,3)];

		}
	}

	public void ChangeLevel()
	{
		if (answers.Length < 5) {
			mainquetion.text = main [answers.Length].question;
			bt1.text = main [answers.Length].first;
			bt2.text = main [answers.Length].second;
			bt3.text = main [answers.Length].third;
			bt4.text = main [answers.Length].fourth;
			
		} else {
			EndQuiz ();
		}
	}

	public void FirstClicked()
	{
		answers += "1";
		ChangeLevel ();
	}
	public void SecondClicked()
	{
		answers += "2";
		ChangeLevel ();
	}
	public void ThirdClicked()
	{
		answers += "3";
		ChangeLevel ();
	}
	public void FourthClicked()
	{
		answers += "4";
		ChangeLevel ();
	}

	public void checkResults()
	{
		for(int i=0;i<5;i++)
		{
			if (answers [i] == (main [i].rightopt))
				mark++;
			}
				
	}

	public void setmark()
	{
		
	}





	public void StartQuiz()
	{
		QuizCanvas.SetActive (true);
		ChangeLevel ();
		
	}
	public void EndQuiz()
	{
		checkResults ();
		Debug.Log ("MARK "+mark);
		QuizCanvas.SetActive (false);
		Debug.Log (answers);
		joy.SetActive (true);
		npcs.SetActive (true);

	}



}

public class quiz{
	public int id;
	public string question;
	public string first;
	public string second;
	public string third;
	public string fourth;
	public char rightopt;

	public quiz()
	{
		this.id = 0;
		this.question = "";
		this.first = "";
		this.second = "";
		this.third = "";
		this.fourth = "";
		this.rightopt = '0';
	}

	public quiz(int id,string question,string first, string second, string third, string fourth,char rightopt)
	{
		this.id = id;
		this.question = question;
		this.first = first;
		this.second = second;
		this.third = third;
		this.fourth = fourth;
		this.rightopt = rightopt;
	}
}