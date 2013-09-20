using UnityEngine;
using System.Collections;

public class GUICrosshair : MonoBehaviour 
{
	/// <summary>
	/// The crosshair texture.
	/// </summary>
	public 	Texture2D 	crosshairTexture;
	
	private Rect 	 	m_crosshairRect;
		
	// Use this for initialization
	void Start () 
	{
		float x = ( Screen.width  / 2 ) - ( crosshairTexture.width  / 2 );
    	float y = ( Screen.height / 2 ) - ( crosshairTexture.height / 2 );
		
		m_crosshairRect = new Rect( x, y, crosshairTexture.width, crosshairTexture.height );
	}
	
	void OnGUI() 
	{
		GUI.DrawTexture( m_crosshairRect, crosshairTexture );
	}
	
	void Update () 
	{	
	}
}
