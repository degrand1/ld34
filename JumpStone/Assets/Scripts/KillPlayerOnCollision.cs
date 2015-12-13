using UnityEngine;
using System.Collections;

public class KillPlayerOnCollision : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D Other )
	{
		if( Other.gameObject.tag == "Player" )
		{
			Other.gameObject.GetComponent<PlayerMovement>().KillPlayer();
		}
	}
}
