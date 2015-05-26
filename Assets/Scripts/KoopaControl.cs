using UnityEngine;
using System.Collections;

public class KoopaControl : MonoBehaviour {
	public float maxSpeed = 5f;
	public bool facingRight = true;
	
	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	bool jump;
	
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	
	void FixedUpdate () {		
		
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs (move));
		GetComponent<Rigidbody2D>().velocity = new Vector2(move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();

		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
			if (GetComponent<Rigidbody2D>().velocity.y < 0.002f || GetComponent<Rigidbody2D>().velocity.y > 0.002f)
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * 220);
	}


	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

