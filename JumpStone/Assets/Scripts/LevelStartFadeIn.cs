using UnityEngine;
using System.Collections;

public class LevelStartFadeIn : MonoBehaviour 
{
	void Start() {
		Fadeout f = GetComponent<Fadeout>();
		if ( f != null ) {
			f.FadeFrom();
		}
	}
}
