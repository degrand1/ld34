using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float Speed;
	public float AirSpeed;

	public enum PlayerState {
		Running,
		Jumping
	};

	PlayerState State = PlayerState.Running;

	private Rigidbody2D R2D;

	// Use this for initialization
	void Start () {
		R2D = transform.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxisRaw( "Horizontal" );
		R2D.velocity = new Vector2( State == PlayerState.Running ? Speed*h : AirSpeed*h, R2D.velocity.y );
	}

	public void Jump(float JumpSpeed) {
		R2D.velocity = new Vector2( R2D.velocity.x, JumpSpeed );
	}

	public void KillPlayer(){
		Invoke ( "RestartLevel", 0.5f );
	}

	void RestartLevel()
	{
		Application.LoadLevel( Application.loadedLevel );
	}
}
