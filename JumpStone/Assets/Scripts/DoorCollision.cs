using UnityEngine;
using System.Collections;

public class DoorCollision : MonoBehaviour {

	public string NextLevel;

	void OnTriggerEnter2D( Collider2D other )
	{
		if( other.gameObject.tag == "Player" )
		{
			Fadeout f = GetComponent<Fadeout>();
			if ( f != null ) {
				Invoke ( "LoadNextLevel", f.fadeTimeSeconds );
				f.FadeTo();
			} else {
				LoadNextLevel();
			}
		}
	}

	void LoadNextLevel() {
		Application.LoadLevel( NextLevel );
	}
}
