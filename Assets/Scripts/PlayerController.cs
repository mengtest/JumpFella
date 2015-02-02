using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	bool facingLeft = true;
	bool grounded = false;
	
	public float maxSpeed = 60f;
	public float groundRadius = 1f;
	public float jumpForce = 10f;
	
	public static PlayerController Instance;
	
	public Transform groundCheck;
	public LayerMask whatIsGround;
	
	Animator anim;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		
		float move = Input.GetAxis ("Horizontal");
		
		anim.SetFloat("Speed", Mathf.Abs(move));
		
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		
		if(move > 0 && facingLeft)
			Flip ();
		else if(move < 0 && !facingLeft)
			Flip ();
	}
	
	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
	}
	
	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
