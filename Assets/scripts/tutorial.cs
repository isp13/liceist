using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour {
	public string[] wordstosay=new string[10];
	public Text textt;

	int id=0;
	// Use this for initialization
	void Start () {
		wordstosay[0]="Добро пожаловать в лицей НИУ ВШЭ!";
		wordstosay[1]="Вы успешно сдали экзамены и были зачислены на направление матинфо!";
		
	}

	public void buttonwaspressed()
	{
		textt.text="";
		typewords (id);
		id++;
	}

	public void typewords(int id)
	{
		StopAllCoroutines ();
		StartCoroutine (TypeSentence(wordstosay[id]));
	}

	IEnumerator TypeSentence(string sentence)
	{
		
		foreach (char letter in sentence.ToCharArray()) {
			textt.text += letter;
			yield return null;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
