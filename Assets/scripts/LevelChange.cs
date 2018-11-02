/*
  Скрипт смены игровых сцен- телепортации в указанную точку хуz координат
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChange : MonoBehaviour {

	public GameObject maincharacter;
	public int xcoords;
	public int ycoords;

	[SerializeField] private string loadlevel;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player"))
			maincharacter.transform.position = new Vector3(xcoords, ycoords, -10f);
			//SceneManager.LoadScene(loadlevel);
	}
}
