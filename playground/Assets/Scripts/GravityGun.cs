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
	public float catchRange = 15.0f;
	/// <summary>
	/// The default hold distance from the player.
	/// </summary>
	public float holdDistance = 4.0f;
	/// <summary>
	/// The default minimum force if accumulate is enable.
	/// </summary>
	//float minForce = 1000;
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
	public LayerMask layerMask = -1;
	
	/// <summary>
	/// Gravity gun state enumeration.
	/// </summary>
	private enum GravityGunState { Free, Catch, Charge, Release, Drop };
	/// <summary>
	/// The initial state of the gravity gun.
	/// </summary>
	private GravityGunState gravityGunState = GravityGunState.Free;
	
	/// <summary>
	/// The rigid body to hold.
	/// </summary>
	private Rigidbody rigid = null;
	/// <summary>
	/// The default current force.
	/// </summary>
	private float currentForce = 40;
	
	/// <summary>
	/// The time to wait after throwing to pick an object.
	/// </summary>
	private float pickWait = 0;
	
	/// <summary>
	/// Fixeds the update.
	/// </summary>
	void FixedUpdate () 
	{
		if( pickWait > 0 )
		{
			pickWait -= Time.fixedDeltaTime;
			return;	
		}
		
		switch( gravityGunState )
		{
		case GravityGunState.Free:
			if( Input.GetButton( "Fire1" ) ) 
			{
	            RaycastHit hit;
	
	            if( Physics.Raycast( transform.position, transform.forward, 
									out hit, catchRange, layerMask ) ) 
				{
	                if( hit.rigidbody ) 
					{
	                    rigid = hit.rigidbody;
						rigid.useGravity = false;
	                    gravityGunState = GravityGunState.Catch;
	                }
	            }
	        }
			break;
			
		case GravityGunState.Catch:
			rigid.MovePosition(transform.position + transform.forward * holdDistance);
			
			if( !Input.GetButton( "Fire1" ) )
			{
	            gravityGunState = GravityGunState.Charge;
			}
			break;
		
		case GravityGunState.Charge:
			rigid.MovePosition(transform.position + transform.forward * holdDistance);
			if( Input.GetButton( "Fire1" ) )
			{
	            gravityGunState = GravityGunState.Release;
			}
			else if( Input.GetButton( "Fire2" ) )
			{
				gravityGunState = GravityGunState.Drop;
			}
			break;
			
		case GravityGunState.Drop:
			rigid.useGravity = true;
	        gravityGunState = GravityGunState.Free;
			rigid = null;
			break;
			
		case GravityGunState.Release:
			pickWait = 1.0f;
			rigid.useGravity = true;
			rigid.AddForce( transform.forward * currentForce, ForceMode.Impulse );
	        gravityGunState = GravityGunState.Free;
			rigid = null;
			break;
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
