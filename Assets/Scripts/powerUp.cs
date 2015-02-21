using UnityEngine;
using System.Collections;

public class powerUp : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController.HatGive();
		//Destroy(gameObject);
		gameObject.particleSystem.emissionRate = 0;
		gameObject.renderer.enabled = false;
		gameObject.collider2D.enabled = false;
	}
}
