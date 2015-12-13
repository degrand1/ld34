using UnityEngine;
using System.Collections;

public class ScriptedMovement : MonoBehaviour {
	public enum Easing {
		QuadInOut,
		SineInOut,
	};

	public GameObject start;
	public GameObject end;
	public float duration = 1f;
	public float pause = 0.5f;
	public Easing easing = Easing.QuadInOut;

	void Start () {
		if ( start == null || end == null ) {
			Debug.Log( transform.gameObject.name + " scripted movement disabled! Start or End is null!" );
			enabled = false;
		}
	}

	void Update () {
	}
}
