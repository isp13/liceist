﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//чтобы начать диалог
public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public void TriggerDialogue()
	{
		FindObjectOfType<DialogSystem> ().StartDialogue (dialogue);
	}
}
