using UnityEngine;
using System.Collections;

public class BombLauncher : MonoBehaviour 
{
	
	/// <summary>
	/// The object you want to throw.
	/// </summary>
	public GameObject BombPrefab;
	
	public float spawnDistance = 1.0f;
	public float force = 700.0f;
	
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
	       GameObject bomb = (GameObject) Instantiate( BombPrefab, 
								transform.position + spawnDistance * transform.forward, 
								BombPrefab.transform.rotation);
			
		   bomb.rigidbody.AddForce(transform.forward * force);
		}
	}
}
