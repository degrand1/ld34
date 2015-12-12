using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
	public float Speed = 1.0f;
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3( 0f, 0f, -Speed );
	}
}
