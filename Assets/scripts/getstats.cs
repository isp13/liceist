using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getstats : MonoBehaviour {
	
	public GameObject maincharacter;
	public GameObject load;
	public string whichstatstoup;
	public int howmuch;
	public string whichstatstodown;
	public int howmuch2;
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
				if (whichstatstodown=="tiredness" && PlayerPrefs.GetInt("tiredness")>=5)
				{ 
					maincharacter.GetComponent<playerControl>().freezemovement();
					load.SetActive(true);
					maincharacter.GetComponent<Animator>().Play("loadingtaba");
					StartCoroutine("wait");
				 //load.SetActive(false);
				 //maincharacter.GetComponent<playerControl>().unfreezemovement();
				}
				 
			}
	}

	IEnumerator wait()
 {
    //Do whatever you need done here before waiting
 
    yield return new WaitForSeconds (4f);
	load.SetActive(false);
	if (whichstatstoup=="IQ")
	{
		int iq=PlayerPrefs.GetInt("IQ");
		int tired=PlayerPrefs.GetInt("tiredness");
		PlayerPrefs.SetInt("IQ",iq+howmuch);
		PlayerPrefs.SetInt("tiredness",tired-5);
	}
	if (whichstatstoup=="tiredness")
	{
		
		int tired=PlayerPrefs.GetInt("tiredness");
		
		PlayerPrefs.SetInt("tiredness",tired+5);
	}
	
	maincharacter.GetComponent<playerControl>().unfreezemovement();
 }
}
