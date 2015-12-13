using UnityEngine;
using System.Collections;

// ONLY WORKS FOR FALLING RIGHT NOW
public class JellyAnimation : MonoBehaviour {
	public Vector2 maxVelocity = new Vector2( 100f, 100f );
	public GameObject view;
	public Vector3 originalScale;
	public Rigidbody2D R2D;

	public void Start() {
		if ( view == null ) {
			view = transform.Find( "View" ).gameObject;
			if ( view == null ) {
				view = gameObject;
			}
		}
		originalScale = transform.localScale;
		R2D = GetComponent<Rigidbody2D>();
	}

	public void Update() {
		float unitVelocity = Mathf.Abs( R2D.velocity.y ) / maxVelocity.y;
		Vector2 scale = new Vector2( Mathf.Lerp ( 0.7f, 1f, 1f - unitVelocity ), Mathf.Lerp ( 1f, 5f/3f, unitVelocity ) );
		view.transform.localScale = new Vector3( originalScale.x * scale.x, originalScale.y * scale.y, 1 );
	}
}
