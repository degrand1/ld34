﻿using UnityEngine;
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
	private bool dead;
	private GameObject view;
	private bool checkpointHit = false;
	private Vector3 checkpointLocation;

	// Use this for initialization
	void Start () {
		dead = false;
		R2D = transform.GetComponent<Rigidbody2D>();
		view = transform.Find( "View" ).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		// land
		if ( State == PlayerState.Jumping && R2D.velocity.y <= 0 ) {
			RaycastHit2D hit = Physics2D.Linecast( transform.position, new Vector2( transform.position.x, transform.position.y - transform.lossyScale.y / 2 - 0.1f), 1 << LayerMask.NameToLayer( "Platform" ) );
			if ( hit.collider != null ) {
				State = PlayerState.Running;
				transform.parent = hit.transform;
			}
		}
		else if( State == PlayerState.Running ) {
			RaycastHit2D hit = Physics2D.Linecast( transform.position, new Vector2( transform.position.x, transform.position.y - transform.lossyScale.y / 2 - 0.1f ), 1 << LayerMask.NameToLayer( "Platform" ) );
			if ( hit.collider == null && transform.parent != null ) {
				State = PlayerState.Jumping;
				transform.parent = null;
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
		if ( !dead ) {
			dead = true;
			BroadcastMessage( "GameOver" );
			BroadcastMessage( "EmitParticles" );
			view.GetComponent<Spin>().degreesPerSecond = 960f;
			Invoke ( "RestartLevel", 0.5f );
			PlayerPrefs.SetInt( "RekageCount", PlayerPrefs.GetInt( "RekageCount" ) + 1 );
		}
	}

	public void HitCheckpoint(Vector3 Location)
	{
		checkpointHit = true;
		checkpointLocation = Location;
	}

	void RestartLevel()
	{
		if( checkpointHit )
		{
			view.GetComponent<Spin>().degreesPerSecond = 0;
			view.transform.rotation = Quaternion.identity;
			BroadcastMessage( "GameOverOver" );
			foreach( GameObject stone in GameObject.FindGameObjectsWithTag("Stone") )
				stone.GetComponent<JumpStoneCollision>().ResetStone();
			transform.position = checkpointLocation;
			Vector3 CameraPosition = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
			GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3( checkpointLocation.x, checkpointLocation.y, CameraPosition.z );
			dead = false;
			R2D.velocity = new Vector2( 0f, 0f );
		}
		else
		{
			Application.LoadLevel( Application.loadedLevel );
		}
	}
}
