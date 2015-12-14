using UnityEngine;
using System.Collections;

public class CheckpointHit : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D Other )
	{
		if( Other.gameObject.tag == "Player" )
		{
			Other.gameObject.GetComponent<PlayerMovement>().HitCheckpoint(transform.position);
		}
	}
}
