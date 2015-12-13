using UnityEngine;
using System.Collections;

public class StoneParticleEmitter : MonoBehaviour {
	public GameObject particle = null;
	public float numEmitted = 10;
	public float emitDistance = 2;

	void Start () {
	}

	void Update () {
		
	}

	void EmitParticles() {
		if ( particle != null ) {
			for ( int i = 0; i < numEmitted; i++ ) {
				GameObject p = Instantiate( particle );
				ParticleController pc = p.GetComponent<ParticleController>();
				pc.p1 = transform.position;
				float theta = Mathf.Deg2Rad * ( i * 360f / numEmitted );
				pc.p2 = new Vector3( pc.p1.x + Mathf.Sin( theta ) * emitDistance
													 , pc.p1.y + Mathf.Cos( theta ) * emitDistance
													 , pc.p1.z );
			}
		}
	}
}
