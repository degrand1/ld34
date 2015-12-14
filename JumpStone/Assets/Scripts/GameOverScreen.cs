using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {
	bool hasPlayedWarningSfx = false;
	public Texture2D gameover;

	void Start() {
		enabled = false;
	}

	void OnGUI() {
		if ( gameover != null ) {
			GUI.Label( new Rect( ( Screen.width - gameover.width ) / 2, ( Screen.height - gameover.height ) / 2, gameover.width, gameover.height ),
								 gameover );
		}
	}

	void GameOver() {
		enabled = true;
	}

	void GameOverOver() {
		enabled = false;
	}

	void Update() {
		if ( !hasPlayedWarningSfx ) {
			// AudioSource.PlayClipAtPoint( warningSfx, new Vector2( transform.position.x, transform.position.y ) );
			hasPlayedWarningSfx = true;
		}
	}
}
