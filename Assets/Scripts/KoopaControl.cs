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

	Vector3 velocity = Vector3.zero;
	
	Animator animator;
	bool right, left, down, jump, superJump;
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	//Graphics update here
	void Update(){
		if (Input.GetMouseButtonDown (0) || Input.GetKeyDown (KeyCode.Space)) {
			//			if (transform.position.y >= -0.58f && transform.position.y <= -0.55f)
			if (GetComponent<Rigidbody2D>().velocity.y < 0.002f && GetComponent<Rigidbody2D>().velocity.y > -0.002f)
				jump = true;
		} if (Input.GetKey(KeyCode.RightArrow)) {
			right = true;
		} if (Input.GetKey(KeyCode.LeftArrow)) {
			if (transform.position.x >= 0.6854517f) 
				left = true;
		} if (Input.GetKeyDown(KeyCode.UpArrow)) {
			//			if (transform.position.y >= -0.58f && transform.position.y <= -0.55f)
			if (GetComponent<Rigidbody2D>().velocity.y < 0.002f && GetComponent<Rigidbody2D>().velocity.y > -0.002f)
				jump = true;
		} if (Input.GetKey(KeyCode.DownArrow)) {
			down = true;
		} 
	}
	
	// Update is called once per frame
	// Physics updates here
	void FixedUpdate () {

		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs (move));

		if (jump) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * 180.0f);
			//			rigidbody2D.AddForce(Vector2.right * 450.0f);
			jump = false;
		} if (right) {
			transform.position = new Vector2(transform.position.x + 0.025f, transform.position.y);
			if (!facingRight)
				Flip ();
			right = false;
		} if (left) {
			transform.position = new Vector2(transform.position.x - 0.025f, transform.position.y);
			if (facingRight)
				Flip ();
			left = false;
		} if (down) {
			GetComponent<Rigidbody2D>().AddForce (Vector2.up * -20.0f);
			down = false;
		} if (superJump) {
			GetComponent<Rigidbody2D>().AddForce(Vector2.up * 100.0f);
			superJump = false; 
		}
	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

