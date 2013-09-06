using UnityEngine;
using System.Collections;

public class CannonBall: MonoBehaviour 
{
	/// <summary>
	/// The object you want to throw.
	/// </summary>
	public GameObject Cannonball;
	
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
	       GameObject ball = (GameObject) Instantiate(Cannonball, transform.position, Quaternion.identity);
	       ball.transform.position = target.position;
			
		   ball.rigidbody.AddForce(129f, 0, 700f);
		   ball.rigidbody.useGravity = true;
	       Destroy(ball, 10);
		}
	}
}
