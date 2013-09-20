using UnityEngine;
using System.Collections;

public class DynamiteTimer : MonoBehaviour 
{
	public TextMesh   	  text;
	public TimedExplosion timer;
	
	void Start()
	{
	}

	void Update() 
    {
		text.text = timer.getTimeLeft().ToString( "0.00" );
    }
}