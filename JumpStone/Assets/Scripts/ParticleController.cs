using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour {
	public enum ScriptedMovementState {
		MOVING,
		FADING,
	};

	public Vector3 p1;
	public Vector3 p2;
	public float duration = 1f;

	private float acc = 0f;
	private SpriteRenderer r = null;

	void Start () {
		if ( r == null ) r = GetComponent<SpriteRenderer>();
	}

	void Update () {
		acc += Time.deltaTime;

		if ( acc < duration ) {
			float t = Easing.Quadratic.Out( acc / duration );
			transform.position = Vector3.Lerp( p1, p2, t );
			if ( r != null ) r.color = new Color( r.color.r, r.color.g, r.color.b, 1 - t );
		} else {
			Destroy( gameObject );
		}
	}
}
