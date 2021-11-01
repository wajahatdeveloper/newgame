using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public Animator animator;
	public float jumpForce;
	public float rollTime;
	public GameObject normalCollider;
	public GameObject rollCollider;
	public GameObject explosion;
	public GameController controller;

	private Vector3 originalScale;

	private void Start()
	{
		animator.speed = 2;
		// originalScale = new Vector3(0.7f,0.7f,1.0f);
		animator.Play( "Running" );
	}

	private void OnDisable()
	{
		StopAllCoroutines();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}

		if (Input.GetKeyDown(KeyCode.LeftShift))
		{
			Roll();
		}
	}

	public void Jump()
	{
		animator.Play( "Jumping" );
		this.Invoke(()=>animator.Play("Running"),2.0f);
		rollCollider.SetActive( false );
		normalCollider.SetActive( true );
		GetComponent<Rigidbody2D>().AddForce( Vector2.up * jumpForce, ForceMode2D.Impulse);
		CancelRoll();
	}

	public void Roll()
	{
		animator.Play( "Rolling" );
		rollCollider.SetActive( true );
		normalCollider.SetActive( false );
		//var yScale = transform.localScale;
		//yScale.y = 0.4f;
		//transform.localScale = yScale;

		this.Invoke( () =>
		{
			CancelRoll();
		}
		, rollTime );
	}

	private void CancelRoll()
	{
		animator.Play( "Running" );
		rollCollider.SetActive( false );
		normalCollider.SetActive( true );
		//transform.localScale = originalScale;
	}

	private void OnTriggerEnter2D( Collider2D collision )
	{
		if ( collision.CompareTag("Obstacle") == false ) { return; }

		Destroy( collision.gameObject );
		Instantiate( explosion, transform );
		CancelRoll();
		enabled = false;
		animator.Play( "Death" );
		controller.LostPre();
	}
}