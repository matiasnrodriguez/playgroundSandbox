using UnityEngine;
using System.Collections;

/// <summary>
/// Explosion behavoir, attach to a rigit body asset.
/// </summary>
public class Explosion : MonoBehaviour 
{
	
	/// <summary>
	/// The explosion animation object.
	/// </summary>
	public Transform explosionPrefab;
	/// <summary>
	/// The radius or range of the explosion.
	/// </summary>
	float radius = 150.0f;
	/// <summary>
	/// The power of the explosion.
	/// </summary>
	float power = 500.0f;
	
	// Use this for initialization
	void Start ()
	{
		
	
	}
	
	void Update () 
	{
	
	}
	
	/// <summary>
	/// Raises the collision enter event for the explosion.
	/// </summary>
	/// <param name='collision'>
	/// Collision object, aka "the bomb", needs to have a rigit body attached.
	/// </param>
	void OnCollisionEnter(Collision collision) 
	{
		// Applies an explosion force to all nearby rigidbodies
		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere (explosionPos, radius);
		
		foreach (Collider hit in colliders) 
		{
			if (!hit)
				continue;
			
			if (hit.rigidbody)
				hit.rigidbody.AddExplosionForce(power, explosionPos, radius);
		}
		
		// Rotate the object
		ContactPoint contact = collision.contacts[0]; 
		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal); 
		
		Vector3 pos = contact.point; 
		Instantiate(explosionPrefab, pos, rot); 
		
		// Destroy the projectile 
		Destroy (gameObject);
	}
	
}
