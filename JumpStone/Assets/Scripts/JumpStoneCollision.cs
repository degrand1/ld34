using UnityEngine;
using System.Collections;

public class JumpStoneCollision : MonoBehaviour {

	public float DissappearLength = 2.0f;
	public float JumpSpeed = 8.0f;
	public bool DeleteOnCollision = true;

	private bool CollisionOccurred = false;
	private float DissapperedTime = 0f;
	private SpriteRenderer StoneRenderer;
	private BoxCollider2D StoneCollider;

	void OnTriggerEnter2D( Collider2D Other )
	{
		if( Other.gameObject.tag == "Player" && !CollisionOccurred )
		{
			if( DeleteOnCollision )
			{
				CollisionOccurred = true;
				StoneRenderer.enabled = false;
				StoneCollider.enabled = false;
			}
			BroadcastMessage( "EmitParticles" );
			if ( GetComponent<DropStoneCollision>() == null ) {
				PlayerPrefs.SetInt( "JumpstonesPopped", PlayerPrefs.GetInt( "JumpstonesPopped" ) + 1 );
			}
			Other.gameObject.GetComponent<PlayerMovement>().Jump(JumpSpeed);
		}
	}

	void Start()
	{
		StoneRenderer = transform.GetComponent<SpriteRenderer>();
		StoneCollider = transform.GetComponent<BoxCollider2D>();
	}

	void Update()
	{
		if( CollisionOccurred )
		{
			DissapperedTime += Time.deltaTime;
			if( DissapperedTime >= DissappearLength )
			{
				CollisionOccurred = false;
				StoneRenderer.enabled = true;
				StoneCollider.enabled = true;
				DissapperedTime = 0f;
			}
		}
	}
}
