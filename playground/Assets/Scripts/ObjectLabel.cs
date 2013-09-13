using UnityEngine;
using System.Collections;
 
[RequireComponent( typeof( GUIText ) )]
public class ObjectLabel : MonoBehaviour 
{
	/// <summary>
	/// Object that this label should follow
	/// </summary>
	public 	Transform 	target;
	
	/// <summary>
	/// Units in world space to offset; 1 unit above object by default
	/// </summary>
	public 	Vector3 	offset 			= Vector3.up;
	
	/// <summary>
	/// If true, label will be visible even if object is off screen
	/// </summary>
	public 	bool 		clampToScreen 	= false;
	
	/// <summary>
	/// How much viewport space to leave at the borders when a label is being clamped
	/// </summary>
	public 	float 		clampBorderSize = 0.05f;
	
	/// <summary>
	/// Use the camera tagged MainCamera
	/// </summary>
	public 	bool 		useMainCamera 	= true;
	
	/// <summary>
	/// Only use this if useMainCamera is false
	/// </summary>
	public 	Camera 		cameraToUse;
	
	private Camera 		cam;
	private Transform 	thisTransform;
	private Transform 	camTransform;
 
	void Start () 
    {
	    thisTransform = transform;
	    if( useMainCamera )
		{
	        cam = Camera.main;
		}
		else
		{
	        cam = cameraToUse;
		}
		
		camTransform = cam.transform;
	} 
 
    void Update()
    {
        if( clampToScreen )
        {
            Vector3 relativePosition = camTransform.InverseTransformPoint( target.position );
            relativePosition.z =  Mathf.Max( relativePosition.z, 1.0f );
            thisTransform.position = cam.WorldToViewportPoint( camTransform.TransformPoint( relativePosition + offset ) );
            thisTransform.position = new Vector3( Mathf.Clamp( thisTransform.position.x, clampBorderSize, 1.0f - clampBorderSize ),
                                             	  Mathf.Clamp( thisTransform.position.y, clampBorderSize, 1.0f - clampBorderSize ),
                                             	  thisTransform.position.z );
        }
        else
        {
            thisTransform.position = cam.WorldToViewportPoint( target.position + offset );
        }
    }
}