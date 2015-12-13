using UnityEngine;
using System.Collections;

public class FadeAway : MonoBehaviour {
	public float fadeDelay = 1f;
	public float fadeDuration = 1f;

	private float acc = 0f;
	private SpriteRenderer r = null;

	void Start () {
		if ( r == null ) r = GetComponent<SpriteRenderer>();
	}

	void Update () {
		if ( r == null ) r = GetComponent<SpriteRenderer>();
		acc += Time.deltaTime;
		if ( acc > fadeDelay && acc < fadeDuration + fadeDelay ) {
			float t = Easing.Quadratic.Out( ( acc - fadeDelay ) / fadeDuration );
			if ( r != null ) r.color = new Color( r.color.r, r.color.g, r.color.b, 1 - t );
		} else if ( acc > fadeDuration + fadeDelay ) {
			Destroy( gameObject );
		}
	}
}
