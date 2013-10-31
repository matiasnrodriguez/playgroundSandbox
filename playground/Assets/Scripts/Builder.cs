using UnityEngine;
using System.Collections;

public class Builder : MonoBehaviour 
{
	LayerMask blockLayer = 1; 
	float range = Mathf.Infinity; 
	RaycastHit hit;
	
	public GameObject SpecialEffect;
	public GameObject DestroySpecialEffect;
	
	public GameObject WallPrefab;
	public GameObject CylinderPrefab;
	public GameObject BoxPrefab;
	public GameObject PillarPrefab;
	
	GameObject currentPrefab;
	
	
	// Use this for initialization
	void Start ()
	{
		currentPrefab = CylinderPrefab;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
       	{
        	currentPrefab = CylinderPrefab; 
            print("Cylinder");
       	}
		
		if (Input.GetKeyDown(KeyCode.Alpha2))
       	{
        	currentPrefab = BoxPrefab; 
            print("Box");
       	}
		
		if (Input.GetKeyDown(KeyCode.Alpha3))
       	{
        	currentPrefab = WallPrefab; 
            print("Wall");
       	}
		
		if (Input.GetKeyDown(KeyCode.Alpha4))
       	{
        	currentPrefab = PillarPrefab; 
            print("Pillar");
       	}
		
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			Build(); 
		}
		if(Input.GetKeyDown(KeyCode.Mouse1))
		{
			Erase(); 
		}
		if (Input.GetKeyDown(KeyCode.R))
		{
	    	RotateUp();		
		}
		
		if (Input.GetKeyDown(KeyCode.T))
		{
	    	RotateLeft();		
		}
	}
	
	/// <summary>
	/// Build using the selected primitive.
	/// </summary>
	void Build()
	{ 
		if (HitBlock())
		{ 
			GameObject sparks = (GameObject)Instantiate(SpecialEffect, hit.transform.position + hit.normal, currentPrefab.transform.rotation);
			Destroy (sparks, 2.0f);
			
			Instantiate( currentPrefab, 
						 hit.transform.position + hit.normal, 
						 currentPrefab.transform.rotation
				       );
			
			/*GameObject sparks = (GameObject)Instantiate(SpecialEffect, hit.point, currentPrefab.transform.rotation);
			Destroy (sparks, 2.0f);
			
			Instantiate( currentPrefab, 
						 hit.point, 
						 currentPrefab.transform.rotation
				       );*/
		} 
	}
	
	/// <summary>
	/// Erase the pointed primitve.
	/// </summary>
	void Erase()
	{ 
		if (HitBlock())
		{
			if (IsPrimitive(hit.transform.gameObject))
			{
				GameObject destroy = (GameObject)Instantiate(DestroySpecialEffect, hit.transform.position + hit.normal, currentPrefab.transform.rotation);
				Destroy (destroy, 1.0f);
				
				Destroy(hit.transform.gameObject);
			}
		}
	}
	
	bool HitBlock()
	{
		/*		
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		bool retVal = Physics.Raycast (ray, out hit, 100);
		Debug.DrawLine (ray.origin, hit.point);
		
		return retVal;*/
		
		return Physics.Raycast(transform.position, transform.forward, out hit, range, blockLayer); 
	}
	
	bool IsPrimitive(GameObject primitive)
	{
		return ( primitive.tag == "WallPrimitive"
				 || primitive.tag == "BoxPrimitive"
				 || primitive.tag == "CylinderPrimitive"
				 || primitive.tag == "PillarPrimitive"
			   );
	}
	
	void RotateUp()
	{
		if (HitBlock())
		{
			if (IsPrimitive(hit.transform.gameObject))
			{
				hit.transform.Rotate(Vector3.up * 500 * Time.deltaTime);
			}
		}
	}
	
	void RotateLeft()
	{
		if (HitBlock())
		{
			if (IsPrimitive(hit.transform.gameObject))
			{
				hit.transform.Rotate(Vector3.left * 500 * Time.deltaTime);
			}
		}
	}
}
