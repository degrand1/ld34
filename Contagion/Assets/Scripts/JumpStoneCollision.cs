using UnityEngine;
using System.Collections;

public class JumpStoneCollision : MonoBehaviour {

	public float DissappearLength = 2.0f;

	private bool CollisionOccurred = false;
	private float DissapperedTime = 0f;
	private SpriteRenderer StoneRenderer;
	private BoxCollider2D StoneCollider;

	void OnTriggerEnter2D( Collider2D Other )
	{
		if( Other.gameObject.tag == "Player" && !CollisionOccurred )
		{
			CollisionOccurred = true;
			StoneRenderer.enabled = false;
			StoneCollider.enabled = false;
			Other.gameObject.GetComponent<PlayerMovement>().Jump();
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
