using UnityEngine;
using System.Collections;

/// <summary>
/// Gravity gun behaviour.
/// </summary>
public class GravityGun : MonoBehaviour 
{
	/// <summary>
	/// The default catch range for the gravity gun.
	/// </summary>
	float catchRange = 30.0f;
	/// <summary>
	/// The default hold distance from the player.
	/// </summary>
	float holdDistance = 4.0f;
	/// <summary>
	/// The default minimum force if accumulate is enable.
	/// </summary>
	float minForce = 1000;
	/// <summary>
	/// The default max force if accumulate is enable..
	/// </summary>
	//float maxForce = 10000;
	/// <summary>
	/// The default force charge per second if accumulate is enable..
	/// </summary>
	//float forceChargePerSec = 3000;
	/// <summary>
	/// The default layer mask.
	/// </summary>
	LayerMask layerMask = -1;
	
	/// <summary>
	/// Gravity gun state enumeration.
	/// </summary>
	private enum GravityGunState { Free, Catch, Occupied, Charge, Release};
	/// <summary>
	/// The initial state of the gravity gun.
	/// </summary>
	private GravityGunState gravityGunState = 0;
	
	/// <summary>
	/// The rigid body to hold.
	/// </summary>
	private Rigidbody rigid = null;
	/// <summary>
	/// The default current force.
	/// </summary>
	private float currentForce = 1000;
	
	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate () 
	{
	    if(gravityGunState == GravityGunState.Free) 
		{
	        if(Input.GetButton("Fire1")) 
			{
	            RaycastHit hit;
	
	            if(Physics.Raycast(	transform.position, transform.forward, 
									out hit, catchRange, layerMask) ) 
				{
	                if(hit.rigidbody) 
					{
	                    rigid = hit.rigidbody;
	                    gravityGunState = GravityGunState.Catch;
	                }
	            }
	        }
	    }
	    else if(gravityGunState == GravityGunState.Catch) 
		{
	        rigid.MovePosition(transform.position + transform.forward * holdDistance);
	
	        if(!Input.GetButton("Fire1"))
	            gravityGunState = GravityGunState.Occupied;
	    }
	    else if(gravityGunState == GravityGunState.Occupied) 
		{
	        if(!Input.GetButton("Fire1"))
	            gravityGunState = GravityGunState.Charge;
	    }
	    else if(gravityGunState == GravityGunState.Charge) 
		{
	        //rigid.MovePosition(transform.position + transform.forward * holdDistance);
			/*if(currentForce < maxForce) 
			{
	            currentForce += forceChargePerSec * Time.deltaTime;
	        }
	        else 
			{
	            currentForce = maxForce;
	        }*/
	
	        if(!Input.GetButton("Fire1"))
	            gravityGunState = GravityGunState.Release;
	    }
		else if(gravityGunState == GravityGunState.Release) 
		{
	        //rigid.AddForce(transform.forward * currentForce);
	        currentForce = minForce;
	        gravityGunState = GravityGunState.Free;
	    }
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
