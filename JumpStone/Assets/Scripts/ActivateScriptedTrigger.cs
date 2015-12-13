using UnityEngine;
using System.Collections;

public class ActivateScriptedTrigger : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D Other )
	{
		if( Other.gameObject.tag == "Player" )
		{
			transform.parent.GetChild(0).GetComponent<ScriptedMovement>().HitTrigger();
		}
	}
}
