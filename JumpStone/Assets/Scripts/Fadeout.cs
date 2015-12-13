using UnityEngine;
using System.Collections;

public class Fadeout : MonoBehaviour {
	public Texture solidtex;

	private float alphaFadeValue = 0f;
	public float fadeTimeSeconds = 2; // seconds

	private const float TO = 1;
	private const float FROM = -1;
	private const float HOLD = 0;
	private float fadeDirection = HOLD;

	public Color fadeColor;

	public delegate void DoneAction();
	DoneAction doneAction;

	// Use this for initialization
	void Start () {
		doneAction = null;
	}
	
	// Update is called once per frame
	void Update () {
	}

	// multiple times per frame
	void OnGUI() {
		alphaFadeValue += fadeDirection * Mathf.Clamp01( Time.deltaTime / fadeTimeSeconds );
		Color oldColor = GUI.color;
		GUI.color = new Color( fadeColor.r, fadeColor.g, fadeColor.b, alphaFadeValue );
		GUI.DrawTexture( new Rect(0, 0, Screen.width, Screen.height ), solidtex, ScaleMode.StretchToFill, true, 10.0F );
		GUI.color = oldColor;

		// hold state if overboard in either direction
		if ( alphaFadeValue < 0 || alphaFadeValue > 1 ) {
			fadeDirection = HOLD;
			alphaFadeValue = Mathf.Clamp01( alphaFadeValue );
			if ( doneAction != null ) {
				DoneAction OldDoneAction = doneAction;
				doneAction();
				//null out the doneAction unless we assigned a new one
				if( OldDoneAction == doneAction ) doneAction = null;
			}
		}
	}

	public void FadeTo( DoneAction doneAction = null ) {
		fadeDirection = TO;
		alphaFadeValue = 0;
		this.doneAction = doneAction;
	}

	public void FadeFrom( DoneAction doneAction = null ) {
		fadeDirection = FROM;
		alphaFadeValue = 1;
		this.doneAction = doneAction;
	}
}
