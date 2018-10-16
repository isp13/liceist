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
	public quiz[] hist = new quiz[10];
	public quiz[] teorpoz = new quiz[10];
	public quiz[] liter = new quiz[10];
	public quiz[] main=new quiz[10];

	void Start () {
		//MATH
		math [0] = new quiz (0, "Чему равно sin(30)+сos(2pi)-ctg(pi/4)+1/2", "0", "1", "1/2", "3/2", '2');
		math [1] = new quiz (1, "Что такое логарифм числа b по основанию a?", "Показатель степени, в которую нужно возвести a, чтобы получить b", "Показатель степени, в которую нужно возвести b, чтобы получить a", "Число a в степени b", "Не знаю", '1');
		math [2] = new quiz (2, "Укажите иррациональное число", "2*2", "234", "17/18", "sqrt(2)", '4');
		math [3] = new quiz (3, "Что такое синус угла?", "Отношение против.катета к гипотенузе", "Отношение гипотенузы к против.катету", "Тангенс протиивоположного", "1/2 гиипотенузы", '1');
		math [4] = new quiz (4, "Философ и его одноименная теорема", "Аристотель", "Сократ", "Пифагор", "Цицерон", '3');
		//INFORMATICS
		info [0] = new quiz (0, "Что такое массив?", "Элемент базы данных", "Переменная вида string", "структура данных", "Высокая часть горной местности", '3');
		info [1] = new quiz (1, "Чем является TCP?", "основной протокол передачи данных в интернете", "Маршрутизированный сетевой протокол, основа ip", "Протокол пользовательских датаграмм", "Интерфейс для связи устройств", '1');
		info [2] = new quiz (2, "Что такое html?", "Язык программирования", "Библиотека в с++", "Язык сетевых взаимодействий", "Стандартизированный язык разметки документов в Интернете", '4');
		info [3] = new quiz (3, "Что такое ООП?", "Объектно-ориентированное программирование", "Вид функции", "Компилятор языка с++", "Библиотека python", '1');
		info [4] = new quiz (4, "Значение выражение  a++ + ++a (a=1)", "1", "2", "3", "4", '1');
		//RUSSIAN LANGUAGE
		russ [0] = new quiz (0, "Выберите неверно выделенное ударение в слове", "ненАдолго", "Иксы", "понялА", "снятА", '1');
		russ [1] = new quiz (1, "Выберите неверно выделенное ударение в слове", "рвалА", "прибылА", "налилА", "клалА", '4');
		russ [2] = new quiz (2, "Выберите неверно выделенное ударение в слове", "звонИшь", "принЯвший", "начАв", "пОняв", '4');
		russ [3] = new quiz (0, "Выберите неверно выделенное ударение в слове", "ненАдолго", "Иксы", "понялА", "снятА", '1');
		russ [4] = new quiz (1, "Выберите неверно выделенное ударение в слове", "рвалА", "прибылА", "налилА", "клалА", '4');
		//PREPARED QUESTIONS
		main [0] = new quiz (0, "Выберите неверно выделенное ударение в слове", "ненАдолго", "Иксы", "понялА", "снятА", '1');
		main [1] = new quiz (1, "Выберите неверно выделенное ударение в слове", "рвалА", "прибылА", "налилА", "клалА", '4');
		main [2] = new quiz (2, "Выберите неверно выделенное ударение в слове", "звонИшь", "принЯвший", "начАв", "пОняв", '4');
		main [3] = new quiz (0, "Выберите неверно выделенное ударение в слове", "ненАдолго", "Иксы", "понялА", "снятА", '1');
		main [4] = new quiz (1, "Выберите неверно выделенное ударение в слове", "рвалА", "прибылА", "налилА", "клалА", '4');

		//PHILOSOPHY
		teorpoz [0] = new quiz (0, "Как философия переводится с греческого языка?", "Любовь к истине", "Любовь к мудрости", "Учение о мире", "божественная мудрость", '2');
		teorpoz [1] = new quiz (1, "Кто назвал себя первым философом?", "Сократ", "Аристотель", "Пифагор", "Цицерон", '3');
		teorpoz [2] = new quiz (2, "Определиите время возниикновения философии", "Середина 3 тыс до н.э", "7-6 в.в до н.э", "17-18 в.в", "5-15 в.в", '2');
		teorpoz [3] = new quiz (3, "Направлениие, отрицающее существования Бога", "Атеизм", "Скептицизм", "Агностицизм", "Неотомизм", '1');
		teorpoz [4] = new quiz (3, "Какое полное имя известного психолога Фрейда? ", "Зигизмунд", "Зигманд", "Зигмунд", "Сигзмунд", '3');

		//HISTORY
		hist [0] = new quiz (0, "Даты первой мировой войны", "1914-1917", "1914-1918", "1915-1918", "1914-1918", '2');
		hist [1] = new quiz (1, "Причина первой мировой войны", "Убийство эрцгерцога", "Стремление Англии уничтожить Францию", "Стремление России стать колониальной державой", "Борьба за передел колоний", '1');
		hist [2] = new quiz (2, "Какого союза не было во время первой мировой?", "Антанта", "Тройственный союз", "Антикоминтерновский блок", "Не знаю", '3');
		hist [3] = new quiz (3, "Год подписания пакта о ненападении между СССР и Германией", "1936", "1937", "1938", "1939", '4');
		hist [4] = new quiz (4, "Дата начала второй мировой войны", "3 августа 1939г", "22 июня 1941г", "1 сентября 1939г", "1 сентября 1941г", '3');

		//LITERATURE
		liter [0] = new quiz (0, "Автор Евгения Онегина", "Пушкин", "Грибоедов", "Достоевский", "Толстой", '1');
		liter [1] = new quiz (1, "О каком событи повествует Война и Мир", "Первая мировая", "Вторая мировая", "Шведская война", "Война с Турцией", '1');
		liter [2] = new quiz (2, "Автор произведения Отцы и Дети", "Пушкин", "Достоевский", "Тургенев", "Маяковский", '3');
		liter [3] = new quiz (3, "Что такое метонимия?", "Антоним", "Смежное понятие", "Гипербола", "Литературный повтор", '2');
		liter [4] = new quiz (4, "Год рождения Пушкина", "1839", "1838", "1937", "1837", '4');
	}
	public void Generate(string cls)
	{
		if (cls == "MATH") {
			for(int i=0;i<5;i++)
				main[i]=math[Random.Range(0,5)];
		
		}
		else if (cls == "RUSS") {
			for(int i=0;i<5;i++)
				main[i]=russ[Random.Range(0,5)];

		}
		else if (cls == "INFO") {
			for(int i=0;i<5;i++)
				main[i]=info[Random.Range(0,5)];

		}
		else if (cls == "TEORP") {
			for(int i=0;i<3;i++)
				main[i]=teorpoz[Random.Range(0,5)];

		}
		else if (cls == "HIST") {
			for(int i=0;i<3;i++)
				main[i]=hist[Random.Range(0,5)];

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

		PlayerPrefs.SetInt ("markforquiz",mark);

				
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
		mark = 0;
		answers = "";

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