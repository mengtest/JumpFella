using UnityEngine;
using System.Collections;

public class hurt : MonoBehaviour 
{
	public float height;
	public float width;
	public float wMargin;
	public bool headBop = false;
	public Vector2 ptA;
	public Vector2 ptB;
	public LayerMask playerLayer;
	
	// Use this for initialization
	void Start () 
	{
		height = gameObject.GetComponent<BoxCollider2D>().size.y;
		width = gameObject.GetComponent<BoxCollider2D>().size.x;
		ptA = new Vector2((0 + wMargin), height);
		ptB = new Vector2((width - wMargin), height + 8);
	}
	
	
	void OnCollisionEnter2D(Collision2D other)
	{
		//if(transform.position.y + height >= other.transform.position.y)
			//{
				PlayerController.Damage();
			//}
		//else if(transform.position.y + height < other.transform.position.y)
		//	{
			//	Destroy(gameObject);
			//}
	}
	
	/*
	void FixedUpdate()
	{
		if(Physics2D.OverlapArea(ptA, ptB, playerLayer))
		{
			headBop = true;
		}
	}*/
}
