using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class quiz: MonoBehaviour
{
	public int QuestionId;
	public string subject;
	public string mainquestion;
	public string firstOpt;
	public string secondOpt;
	public string thirdOpt;
	public string fourthOpt;
	public int rightOption;

	public quiz(int QuestionId, string mainquestion, string firstOpt, string secondOpt, string thirdOpt, string fourthOpt,int rightOption)
	{
		this.mainquestion = mainquestion;
		this.firstOpt = firstOpt;
		this.secondOpt = secondOpt;
		this.thirdOpt = thirdOpt;
		this.fourthOpt = fourthOpt;
		this.rightOption = rightOption;


	}

	bool PickedAnswer()
	{
		return true;
	}

}
