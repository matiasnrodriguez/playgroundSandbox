using UnityEngine;
using System.Collections;

/// <summary>
/// First approach for a sticky object.
/// </summary>
public class StickyObject : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/// <summary>
	/// Raises the collision enter event, creates a fixed joint and attach the rigit body, 
	/// is not what we need, just playing around.
	/// </summary>
	/// <param name='c'>
	/// Collision object.
	/// </param>
	void OnCollisionEnter(Collision c) 
	{
		if (c.rigidbody) 
		{
        	FixedJoint joint = gameObject.AddComponent<FixedJoint>();
			joint.connectedBody = c.rigidbody;
			//joint.breakForce = 1.0f;
		}
    }
}
