using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	bool facingLeft = true;
	bool grounded = false;
	static bool hasHat = false;
	static bool damaged = false;
	static bool recovering = false;
	
	public float maxSpeed = 60f;
	public float groundRadius = 1f;
	public float jumpForce = 10f;
	
	public static PlayerController Instance;
	
	public Transform groundCheck;
	public LayerMask whatIsGround;
	
	static Animator anim;
	SpriteRenderer hatRender;
	public GameObject hat;
	
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		hatRender = hat.GetComponentInChildren<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", grounded);
		
		anim.SetFloat("vSpeed", rigidbody2D.velocity.y);
		
		float move = Input.GetAxis ("Horizontal");
		
		anim.SetFloat("Speed", Mathf.Abs(move));
		
		if(damaged == true && recovering == true)
		{
			Hop();
			//damaged = false;
		}
		else if(damaged == false && recovering == false)
		{
			rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		}
		
		if(move > 0 && facingLeft)
			Flip ();
		else if(move < 0 && !facingLeft)
			Flip ();
			
		if(grounded)
			recovering = false;
	}
	
	void Update()
	{
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
		}
		
		if(hasHat == true)
			hatRender.enabled = true;
		else if(hasHat == false)
			hatRender.enabled = false;
	}
	
	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	public static void HatGive()
	{
		if(hasHat == false)
			{
				hasHat = true;
				Debug.Log("Hat Gained");
			}
	}
	
	public static void Damage()
	{
		if(hasHat == true)
		{
			//hasHat = false;
			damaged = true;
			recovering = true;
			anim.SetTrigger("Damage");
			Debug.Log("Hat Lost");
		}
		else if(hasHat == false)
		{
			KillPlayer();
			Debug.Log("Player Dying");
		}
	}
	
	void Hop()
	{
		if(facingLeft == true)
			{
				rigidbody2D.AddForce(new Vector2(100, 150),ForceMode2D.Impulse);
				Debug.Log ("Bounce Left");
				damaged = false;
				//yield return new WaitForSeconds(1);
			}
		else if(facingLeft == false)
			{
				rigidbody2D.AddForce(new Vector2(-100, 150),ForceMode2D.Impulse);
				Debug.Log("Bounce Right");
				damaged = false;
				//yield return new WaitForSeconds(1);
			}
			
	}
	
	public static void KillPlayer()
	{
		Debug.Log("Player Died");
	}
}
