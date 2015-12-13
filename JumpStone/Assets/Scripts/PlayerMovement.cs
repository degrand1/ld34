using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Speed;
	public float AirSpeed;

	public enum PlayerState {
		Running,
		Jumping
	};

	public PlayerState State = PlayerState.Running;

	private Rigidbody2D R2D;

	// Use this for initialization
	void Start () {
		R2D = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		// land
		if ( State == PlayerState.Jumping && R2D.velocity.y <= 0 ) {
			RaycastHit2D hit = Physics2D.Linecast( transform.position, new Vector2( transform.position.x, transform.position.y - transform.lossyScale.y / 2 ), 1 << LayerMask.NameToLayer( "Platform" ) );
			if ( hit.collider != null ) {
				State = PlayerState.Running;
			}
		}
		float h = Input.GetAxisRaw( "Horizontal" );
		R2D.velocity = new Vector2( State == PlayerState.Running ? Speed*h : AirSpeed*h, R2D.velocity.y );
	}

	public void Jump(float JumpSpeed) {
		R2D.velocity = new Vector2( R2D.velocity.x, JumpSpeed );
		State = PlayerState.Jumping;
	}

	public void KillPlayer(){
		BroadcastMessage( "GameOver" );
		Invoke ( "RestartLevel", 0.5f );
	}

	void RestartLevel()
	{
		Application.LoadLevel( Application.loadedLevel );
	}
}
