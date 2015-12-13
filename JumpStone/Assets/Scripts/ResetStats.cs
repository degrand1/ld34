using UnityEngine;
using System.Collections;

public class ResetStats : MonoBehaviour {
	void Start() {
		PlayerPrefs.DeleteKey( "JumpstonesPopped" );
		PlayerPrefs.DeleteKey( "DropstonesHit" );
		PlayerPrefs.DeleteKey( "RekageCount" );
	}
}
