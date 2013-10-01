using UnityEngine;
using System.Collections;

public class CollisionExplosion : MonoBehaviour 
{
	
	public Detonator detonator = null;
	public GameObject body  = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision collision) 
	{
		Explode();
	}
	
	void Explode()
	{
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
