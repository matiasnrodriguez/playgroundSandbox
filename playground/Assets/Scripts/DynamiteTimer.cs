using UnityEngine;
using System.Collections;

public class DynamiteTimer : MonoBehaviour 
{
	private TextMesh  		m_Text;
	private TimedExplosion 	m_Explosion;
	
	void Start()
	{
		m_Text 		= GetComponent<TextMesh>();
		m_Explosion = transform.parent.GetComponent<TimedExplosion>();//GetComponent( "TimedExplosion" ) as TimedExplosion;
	}

	void Update() 
    {
		m_Text.text = m_Explosion.getTimeLeft().ToString( "0.00" );
    }
}