using UnityEngine;
using System.Collections;

public class HatController : MonoBehaviour {

	public SpriteRenderer spriteRenderer;
	public Animator animator;
	public Camera cam;
	public float moveSpeed;
	private float maxWidth;
	private bool canControl;
	private Vector3 targetPosition;

	private void OnEnable()
	{
		animator.speed = 2;
	}

	private void OnDisable()
	{
		animator.speed = 1;
	}

	// Use this for initialization
	void Start () {
	
		//if (cam == null) {
		//	cam = Camera.main;
		//}
		//canControl = false;
		//Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		//Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
		//float hatWidth = GetComponent<Renderer>().bounds.extents.x;
		//maxWidth = targetWidth.x-hatWidth;
	}

	private void Update()
	{
		
	}

	// Update is called once per physics timestep
	void FixedUpdate () {
		//if (canControl) {
		//	//Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		//	//Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);
		//	//float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		//	//targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		//	GetComponent<Rigidbody2D> ().MovePosition (targetPosition);
		//}

		if (Input.GetKey( KeyCode.LeftArrow ))
		{
			animator.Play( "Walking" );
			spriteRenderer.flipX = true;
			targetPosition = transform.position + (Vector3.left * moveSpeed);
			GetComponent<Rigidbody2D>().MovePosition( targetPosition );
		}
		else if (Input.GetKey( KeyCode.RightArrow ))
		{
			animator.Play( "Walking" );
			spriteRenderer.flipX = false;
			targetPosition = transform.position + (Vector3.right * moveSpeed);
			GetComponent<Rigidbody2D>().MovePosition( targetPosition );
		}
		else
		{
			animator.Play( "Idle" );
		}
		/*if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			animator.Play( "Idle" );
		}

		if (Input.GetKeyUp( KeyCode.RightArrow ))
		{
			animator.Play( "Idle" );
		}*/
	}

	public void toggledControl (bool toggle) {
		canControl = toggle;
	}
}
