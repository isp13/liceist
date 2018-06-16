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
	public Clock clk;
	public void LoadStage()  {
		sb.DayEnd ();
		PlayerPrefs.SetInt ("needsnewday", 0);
		clk.StopAllCoroutines ();
		clk.settime (8, 30);

		Application.LoadLevel ("FirstFloor");
		clk.StopAllCoroutines ();
		dialogC.SetActive (true);
		LifeIQC.SetActive (true);
		TimeC.SetActive (true);
		DayEndingC.SetActive (false);
		sb.DayStart ();
	}
}
