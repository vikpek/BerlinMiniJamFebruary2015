using UnityEngine;
using System.Collections;

public class BlackHoleController : MonoBehaviour {

	[SerializeField]
	int blackHoleID;

	[SerializeField]
	GameObject exitHole;

	[SerializeField]
	GameObject previousBlackHole;

	void OnTriggerEnter(Collider enterprise){
		if(previousBlackHole)
		{
			Debug.Log(" enterprise previous: " + enterprise.GetComponent<EnterpriseController>().lastBlackHoleID + " current " + blackHoleID + " should be previous " + previousBlackHole.GetComponent<BlackHoleController>().blackHoleID);
			if(enterprise.GetComponent<EnterpriseController>().lastBlackHoleID == previousBlackHole.GetComponent<BlackHoleController>().blackHoleID)
			{
				Debug.Log("normal time success");
				success(enterprise.gameObject);
				//TODO visual feedback for correct path
			}else{
				fail(enterprise.gameObject);
//				// TODO goto some other black hole
//				GameObject[] blackHoles =  GameObject.FindGameObjectsWithTag("BlackHole");
//
//				bool same = true;
//				int nextWrongBlackHoleID = 0;
//				while(same){
//					nextWrongBlackHoleID = Random.Range(0, blackHoles.Length - 1);
//					if(nextWrongBlackHoleID != nextBlackHole.GetComponent<BlackHoleController>().blackHoleID)
//					{
//						same = false; 
//					}
//				}
//				enterprise.gameObject.transform.position = blackHoles[nextWrongBlackHoleID].transform.position;
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
}
