using UnityEngine;
using System.Collections;

public class TimedExplosion : MonoBehaviour 
{
	/// <summary>
	/// The radius or range of the explosion.
	/// </summary>
	public float radius = 150.0f;
	/// <summary>
	/// The power of the explosion.
	/// </summary>
	public float power = 500.0f;
	
	/// <summary>
	/// The delay of the explosion in seconds.
	/// </summary>
	public float delay = 5.0f;
	
	/// <summary>
	/// The time left before the explosion.
	/// </summary>
	private float m_timeLeft = 0;
	
	// Use this for initialization
	void Start ()
	{	
		m_timeLeft = delay;
	}
	
	void Update () 
	{
		m_timeLeft -= Time.deltaTime;
		if( m_timeLeft <= 0 )
		{
			Explode();	
		}
	}
	
	public float getTimeLeft()
	{
		return m_timeLeft;
	}
	
	void Explode()
	{
		// Applies an explosion force to all nearby rigidbodies
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere( explosionPos, radius );
		
		foreach( Collider hit in colliders ) 
		{
			if( !hit )
			{
				continue;
			}
				
			if( hit.rigidbody )
			{
				hit.rigidbody.AddExplosionForce( power, explosionPos, radius, 2.0f );
			}
		}

		Destroy( gameObject );
	}
}
