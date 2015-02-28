using UnityEngine;
using System.Collections;

public class BlackHoleController : MonoBehaviour {

	public int previousBlackHole
	{
		get; set;
	}

	public int blackHoleID
	{
		get; set;
	}

	[SerializeField]
	GameObject exitHole;

	[SerializeField]
	GameObject risingText;
	

	void Start()
	{
		displayId();
	}

	void OnTriggerEnter(Collider enterprise){
		if(previousBlackHole == -1)
		{
			Debug.Log(" enterprise previous: " + enterprise.GetComponent<EnterpriseController>().lastBlackHoleID + " current " + blackHoleID + " should be previous " + previousBlackHole);
			if(enterprise.GetComponent<EnterpriseController>().lastBlackHoleID == previousBlackHole)
			{
				Debug.Log("normal time success");
				success(enterprise.gameObject);
				//TODO visual feedback for correct path
			}else{
				fail(enterprise.gameObject);
			}

			//special case for first black hole
		}else{
			Debug.Log("first time success");
			success(enterprise.gameObject);
		}

		enterprise.gameObject.transform.position = exitHole.transform.position;
		//cancel mouse target
		GameObject.FindWithTag("Enterprise").GetComponent<ClickMovementController>().setDestinationPosition();
	}

	void success (GameObject enterprise)
	{
		enterprise.GetComponent<EnterpriseController>().lastBlackHoleID = blackHoleID;
		Debug.Log("success");
	}

	void fail (GameObject enterprise)
	{
		Debug.Log ("fail");
	}

	void displayId ()
	{
		risingText.GetComponent<RisingText> ().setup (blackHoleID);
		Instantiate (risingText, transform.position + Vector3.down + Vector3.right * 2, Quaternion.identity);
	}
}
