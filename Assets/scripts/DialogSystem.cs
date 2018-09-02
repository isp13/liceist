using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogSystem : MonoBehaviour {

	public Text nameText;
	public Text dialogueText;
	public GameObject TCanvas;
	public Animator animator;


	private Queue<string> sentences;



	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
		//TCanvas=GameObject.Find ("DialogCanvas");
		TCanvas.SetActive(false);
	}
	
	public void StartDialogue(Dialogue dialogue)
	{
		TCanvas.SetActive(true);
		animator.SetBool ("IsOpen", true);

		nameText.text = dialogue.name; 

		sentences.Clear ();

		foreach (string sentence in dialogue.sentences) {
			sentences.Enqueue (sentence);//добавляем предложения из инфы перса в кью
		}

		DisplayNextSentence ();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0) {
			EndDialogue ();
			return;
		}

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogueText.text += letter;
			yield return null;
		}
	}


	void EndDialogue()
	{
		TCanvas.SetActive(false);
		nameText.text = ""; 
		dialogueText.text = "";
		animator.SetBool ("IsOpen", false);
		Debug.Log ("End of conversation");
	}


}