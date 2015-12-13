using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float degreesPerSecond = 90f;

	void Update() {
		transform.eulerAngles = new Vector3( transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + degreesPerSecond * Time.deltaTime );
	}
}
