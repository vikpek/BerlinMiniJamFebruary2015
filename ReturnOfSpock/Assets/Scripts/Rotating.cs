using UnityEngine;
using System.Collections;

public class Rotating : MonoBehaviour
{
	
	[SerializeField]
	float speed = 10f;
	
	[SerializeField]
	bool direction;

	void Update()
	{

			if( direction ) transform.Rotate( Vector3.up, speed * Time.deltaTime );
			else transform.Rotate( Vector3.down, speed * Time.deltaTime );

	}
}