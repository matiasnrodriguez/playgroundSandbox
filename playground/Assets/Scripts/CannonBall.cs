using UnityEngine;
using System.Collections;

public class CannonBall: MonoBehaviour 
{
	/// <summary>
	/// The object you want to throw.
	/// </summary>
	public GameObject Cannonball;
	
	float spawnDistance = 1.0f;
	float force = 700.0f;
	float cannonBallLifeTime = 15.0f;
	
	public Transform target;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	/// <summary>
	/// Throw the ball if the user is pressing the mouse left click.
	/// </summary>
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
	       GameObject ball = (GameObject) Instantiate( Cannonball, 
								transform.position + spawnDistance * transform.forward, 
								transform.rotation);
			
		   ball.rigidbody.AddForce(transform.forward * force);
	       Destroy(ball, cannonBallLifeTime);
		}
	}
}
