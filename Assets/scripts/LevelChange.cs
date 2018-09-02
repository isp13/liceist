using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChange : MonoBehaviour {

	public GameObject maincharacter;

	[SerializeField] private string loadlevel;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player"))
			maincharacter.transform.position= Vector3.zero;
			//SceneManager.LoadScene(loadlevel);
	}
}
