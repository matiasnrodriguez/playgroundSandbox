using UnityEngine;
using System.Collections;
 
public class CameraFacingBillboard : MonoBehaviour
{
    private Camera m_camera;
	
	void Awake()
	{
		m_camera = Camera.main;
	}
 
    void Update()
	{
		transform.LookAt( m_camera.transform );
    }
}