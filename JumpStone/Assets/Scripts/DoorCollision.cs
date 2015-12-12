using UnityEngine;
using System.Collections;

public class DoorCollision : MonoBehaviour {

	public string NextLevel;

	void OnTriggerEnter2D( Collider2D other )
	{
		if( other.gameObject.tag == "Player" )
		{
			Application.LoadLevel( NextLevel );
		}
	}
}
