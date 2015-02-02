using UnityEngine;
using System.Collections;

public class OneWayPlatform : MonoBehaviour 
{
	public GameObject player;
	public float playerY;
	public float myY;
	public BoxCollider2D myCollider;
	
	void Start () 
	{
		myY = transform.position.y;
		myCollider = GetComponent<BoxCollider2D>();
	}
	
	void Update () 
	{
		playerY = player.transform.position.y;
		
		if(playerY > myY + 8)
			myCollider.enabled = true;
		else
			myCollider.enabled = false;
	}
}
