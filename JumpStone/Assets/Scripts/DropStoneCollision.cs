using UnityEngine;
using System.Collections;

public class DropStoneCollision : MonoBehaviour {

	void OnTriggerEnter2D( Collider2D Other ) {
		if( Other.gameObject.tag == "Player" )
		{
			PlayerPrefs.SetInt( "DropstonesHit", PlayerPrefs.GetInt( "DropstonesHit" ) + 1 );
		}
	}
}
