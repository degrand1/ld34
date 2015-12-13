using UnityEngine;
using System.Collections;

public class MouseToyParticles : MonoBehaviour {
	void OnMouseEnter() {
		BroadcastMessage( "EmitParticles" );
	}
}
