using UnityEngine;
using System.Collections;

public class TimedExplosion : MonoBehaviour
{	
	/// <summary>
	/// The delay of the explosion in seconds.
	/// </summary>
	public float delay = 5.0f;
	
	public GameObject body  = null;
	
	public Detonator detonator = null;
	
	/// <summary>
	/// The time left before the explosion.
	/// </summary>
	private float m_timeLeft = 0;
	
	private bool m_exploted = false;
		
	// Use this for initialization
	void Start ()
	{	
		m_timeLeft  = delay;
	}
	
	void Update () 
	{
		m_timeLeft -= Time.deltaTime;
		if( !m_exploted && m_timeLeft <= 0 )
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
		m_exploted = true;
		if( body )
		{
			Destroy( body );
		}
		
		if( detonator )
		{
			float duration = detonator.destroyTime;
			detonator.Explode();
			Destroy( gameObject, duration );
		}
		else
		{
			Destroy( gameObject );
		}
	}
}
