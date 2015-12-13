using UnityEngine;
using System.Collections;

public class ScriptedMovement : MonoBehaviour {
	public enum EaseType {
		Linear,
		QuadInOut,
		SineInOut,
	};

	public enum ScriptedMovementState {
		P1_TO_P2,
		PAUSE_P2,
		P2_TO_P1,
		PAUSE_P1,
	};

	public enum ScriptedMovementBehavior {
		ONE_DIRECTION,
		CYCLE,
		CYCLE_LOOP
	};

	private GameObject p1;
	private GameObject p2;
	public float duration = 1f;
	public float pause = 0.5f;
	public EaseType easing = EaseType.QuadInOut;
	public ScriptedMovementState state = ScriptedMovementState.PAUSE_P1;
	public ScriptedMovementBehavior behavior = ScriptedMovementBehavior.CYCLE_LOOP;

	private float acc = 0f;

	void Start () {
		p1 = transform.parent.GetChild (1).gameObject;
		p2 = transform.parent.GetChild (2).gameObject;
		if ( p1 == null || p2 == null ) {
			Debug.Log( transform.gameObject.name + " scripted movement disabled! P1 or P2 is null!" );
			enabled = false;
		}
	}

	void Update () {
		acc += Time.deltaTime;

		switch ( state ) {
			case ScriptedMovementState.PAUSE_P1:
				if ( acc < pause ) {
					transform.position = p1.transform.position;
				} else {
					acc = 0f;
					state = ScriptedMovementState.P1_TO_P2;
					transform.position = p1.transform.position;
				}
				break;
			case ScriptedMovementState.PAUSE_P2:
				if ( acc < pause ) {
					transform.position = p2.transform.position;
				} else {
					acc = 0f;
					state = ScriptedMovementState.P2_TO_P1;
					transform.position = p2.transform.position;
				}
				break;
			case ScriptedMovementState.P1_TO_P2:
				if ( acc < duration ) {
					float t = ease( acc / duration );
					transform.position = Vector3.Lerp( p1.transform.position, p2.transform.position, t );
				} else {
					if ( behavior == ScriptedMovementBehavior.CYCLE || behavior == ScriptedMovementBehavior.CYCLE_LOOP ) {
						acc = 0f;
						state = ScriptedMovementState.PAUSE_P2;
					}
				}
				break;
			case ScriptedMovementState.P2_TO_P1:
				if ( acc < duration ) {
					float t = ease( acc / duration );
					transform.position = Vector3.Lerp( p2.transform.position, p1.transform.position, t );
				} else {
					if ( behavior == ScriptedMovementBehavior.CYCLE_LOOP ) {
						acc = 0f;
						state = ScriptedMovementState.PAUSE_P1;
					}
				}
				break;
		}
	}

	float ease( float t ) {
		switch ( easing ) {
			case EaseType.Linear:
				return t;
			case EaseType.QuadInOut:
				return Easing.Quadratic.InOut( t );
			case EaseType.SineInOut:
				return Easing.Sine.InOut( t );
			default:
				Debug.Log( "warning: " + easing + " not implemented in switch statement!" );
				return t;
		}
	}
}
