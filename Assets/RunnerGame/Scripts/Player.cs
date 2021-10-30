using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float jumpForce;
	public float rollTime;
	public GameObject normalCollider;
	public GameObject rollCollider;
	public GameObject explosion;
	public GameController controller;

	private Vector3 originalScale;

	private void Start()
	{
		originalScale = transform.localScale;
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
		rollCollider.SetActive( false );
		normalCollider.SetActive( true );
		GetComponent<Rigidbody2D>().AddForce( Vector2.up * jumpForce, ForceMode2D.Impulse);
	}

	public void Roll()
	{
		rollCollider.SetActive( true );
		normalCollider.SetActive( false );
		var yScale = transform.localScale;
		yScale.y = 0.4f;
		transform.localScale = yScale;

		this.Invoke( () => 
		{
			rollCollider.SetActive( false );
			normalCollider.SetActive( true );
			transform.localScale = originalScale;
		}
		, rollTime);
	}

	private void OnTriggerEnter2D( Collider2D collision )
	{
		if ( collision.CompareTag("Obstacle") == false ) { return; }

		Destroy( collision.gameObject );
		Instantiate( explosion, transform );
		enabled = false;
		controller.LostPre();
	}
}