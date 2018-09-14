using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getstats : MonoBehaviour {
	
	public GameObject maincharacter;
	public GameObject load;
	private float timer = 0;
 	private float timerMax = 0;
	[SerializeField] private string loadlevel;
	


	void Start(){
		GameObject maincharacter = GameObject.Find("Player");
		GameObject load = GameObject.Find("loadingtab");
		
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.CompareTag("Player"))
			{
				 maincharacter.GetComponent<playerControl>().freezemovement();
				 load.SetActive(true);
				 maincharacter.GetComponent<Animator>().Play("loadingtaba");
				 StartCoroutine("wait");
				 //load.SetActive(false);
				 //maincharacter.GetComponent<playerControl>().unfreezemovement();
				 
			}
	}

	IEnumerator wait()
 {
    //Do whatever you need done here before waiting
 
    yield return new WaitForSeconds (4f);
	load.SetActive(false);
	maincharacter.GetComponent<playerControl>().unfreezemovement();
 }
}
