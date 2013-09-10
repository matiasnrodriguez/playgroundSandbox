using UnityEngine;
using System.Collections;

/// <summary>
/// Portal behavoir, just handle the position & direction change. No angles and no Rendering yet
/// </summary>
public class PortalBehavoir : MonoBehaviour 
{
	/// <summary>
	/// The other portal game object.
	/// </summary>
	public GameObject otherPortal;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Handles portal object change of position.
	/// </summary>
	/// <param name='trigger'>
	/// Object that is passing over the portal.
	/// </param>
	void OnTriggerStay(Collider trigger)
	{	
		Physics.IgnoreCollision(collider,otherPortal.collider,true);
		
		Vector3 finalPos = otherPortal.transform.position;
		finalPos.z -= 2;
		trigger.transform.position = finalPos;
		trigger.transform.rotation = otherPortal.transform.rotation;
		
		// Translate momentum
		Vector3 velocity = trigger.rigidbody.velocity;
       	velocity = Vector3.Reflect(velocity,trigger.transform.forward);
       	velocity = transform.InverseTransformDirection(velocity);
       	velocity = otherPortal.transform.TransformDirection(velocity);
       	trigger.rigidbody.velocity = velocity;
		
		Physics.IgnoreCollision(collider,otherPortal.collider,false);
	}
}
