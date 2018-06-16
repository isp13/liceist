using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewDayLevel : MonoBehaviour {
	public GameObject dialogC;
	public GameObject LifeIQC;
	public GameObject TimeC;
	public GameObject DayEndingC;
	public SubjectsControl sb;
	public LIFEandIQ lifeaiq;
	public void LoadStage()  {
		sb.DayEnd ();
		PlayerPrefs.SetInt ("needsnewday", 0);

		Application.LoadLevel ("FirstFloor");

		dialogC.SetActive (true);
		LifeIQC.SetActive (true);
		TimeC.SetActive (true);
		DayEndingC.SetActive (false);
		sb.DayStart ();
	}
}
