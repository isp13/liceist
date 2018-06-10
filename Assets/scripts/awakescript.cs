using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Util : MonoBehaviour {
	[MenuItem("Utils/Delete All PlayerPrefs")]
	static public void DeleteAllPlayerPrefs() {
		PlayerPrefs.DeleteAll();
	}
}


