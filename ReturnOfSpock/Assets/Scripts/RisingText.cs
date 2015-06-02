using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class RisingText : MonoBehaviour
{
	[SerializeField]
	bool upwardsFadeout = true;

	[SerializeField]
	int initialFontSize = 40;

	[SerializeField]
	int maxSize = 200;

	Vector3 crdsDelta;
	float alpha;
	float lifeLoss;
	Camera  cam;
	
	public Color color = Color.white;


	// SETUP - call this once after having created the object, to make it 
	// "points" shows the points.
	// "duration" is the lifespan of the object
	// "rise speed" is how fast it will rise over time.
	public void setup(string risingInput)
	{
		GetComponent<TextMesh>().text = risingInput;
		int newSize = initialFontSize + 10;
		if( newSize > maxSize ) newSize = maxSize;
		GetComponent<TextMesh>().fontSize = newSize;
		lifeLoss = 0.3f;
		crdsDelta = new Vector3(0f, 1, 0f);        
	}
	
	void Start() 
	{
		alpha = 1f;
		cam = Camera.main;
		crdsDelta = new Vector3(0f, 1f, 0f);
		lifeLoss = 0.3f;
	}
	
	void Update () 
	{
		if(upwardsFadeout) transform.Translate(crdsDelta * Time.deltaTime, Space.World);
		else transform.Translate(-crdsDelta * Time.deltaTime, Space.World);
		
		alpha -= Time.deltaTime * lifeLoss;
		GetComponent<Renderer>().material.color = new Color(color.r,color.g,color.b,alpha);
		
		if (alpha <= 0f) Destroy(gameObject);
		
		transform.LookAt(cam.transform.position);
		transform.rotation = cam.transform.rotation;        
	}	
}