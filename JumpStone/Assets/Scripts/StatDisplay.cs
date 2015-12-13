using UnityEngine;
using System.Collections;

public class StatDisplay : MonoBehaviour {
	public string StatID = "";

	void Start() {
		int Stat = PlayerPrefs.GetInt( StatID );
		GetComponent<TextMesh>().text = Stat.ToString();
	}
}
