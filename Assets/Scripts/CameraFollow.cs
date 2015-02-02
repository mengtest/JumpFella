using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public GameObject player;
	public float camBorder;
	public float distance;
	public float distanceV;
	public float timing;
	public float offset;
	public float offsetV;
	public float levelEndX = 300;
	public float levelTopY = 100;
	public Vector3 target;
	
	void Start () 
	{
		offset = 0;
		offsetV = 20;
		camBorder = GetComponent<Camera>().orthographicSize/ 2;
	}
	
	void Update () 
	{
		if(player.transform.position.x - transform.position.x > 50)
			offset = 50;
		else if(player.transform.position.x - transform.position.x < -50)
			offset = -50;
		
		//Get the difference between the camera and player
		distance = Mathf.Abs (player.transform.position.x - transform.position.x);
		distanceV = Mathf.Abs (player.transform.position.y - transform.position.y);
		
		//If the player exits the dead zone, camera should target the player
		if(distance > 20 | distanceV > 20)
		{
			target = new Vector3 (player.transform.position.x + offset, player.transform.position.y + offsetV, -8);
		}
		
		//Keeps the camera within the level
		if(target.x <= (0 + camBorder))
		{
			target.x = 0 + camBorder;
		}
		else if(target.x >= (levelEndX - camBorder))
		{
			target.x = levelEndX - camBorder;
		}
		
		if(target.y <= (0 + camBorder))
		{
			target.y = 0 + camBorder;
		}
		else if(target.y >= (levelTopY - camBorder))
		{
			target.y = levelTopY - camBorder;
		}
		
		//If the player is moving fast, move the camera fast
		if(Mathf.Abs(player.rigidbody2D.velocity.y) > 300)
			timing = 10;
		else
			timing = 3;
		
		//Move the camera
		transform.position = Vector3.Lerp(transform.position, target, timing * Time.deltaTime);
	}
}
