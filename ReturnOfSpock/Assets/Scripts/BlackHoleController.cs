using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlackHoleController : MonoBehaviour {

	GameObject spockAvatar;
	GameObject gameController;

	[SerializeField]
	GameObject risingText;

	public int blackHoleID
	{
		get; set;
	}
	

	[SerializeField]
	GameObject exitHole;

	void Start()
	{
		StartCoroutine(waitASec());

		gameController = GameObject.FindGameObjectWithTag("GameController");

	}

	IEnumerator waitASec()
	{
		yield return new WaitForSeconds(1f);
		displaySolution();
	}

	void Update() {
		if (Input.GetKeyDown("space"))
		{
			displaySolution();
		}
		
	}

	void OnTriggerEnter(Collider enterprise){
		displayId();

		Debug.Log(" enterprise previous: " + enterprise.GetComponent<EnterpriseController>().currentId + " current " + blackHoleID);
		if(enterprise.GetComponent<EnterpriseController>().currentId + 1 == blackHoleID)
		{
			Debug.Log("normal time success");
			success(enterprise.gameObject);
			enterprise.GetComponent<EnterpriseController>().currentId = blackHoleID;
			//TODO visual feedback for correct path
		}else{
			enterprise.GetComponent<EnterpriseController>().currentId = -1;
			fail(enterprise.gameObject);
		}


		enterprise.gameObject.transform.position = exitHole.transform.position;
		//cancel mouse target
		GameObject.FindWithTag("Enterprise").GetComponent<ClickMovementController>().setDestinationPosition();
	}

	void success (GameObject enterprise)
	{
		enterprise.GetComponent<EnterpriseController>().currentId = blackHoleID;
		GameObject warpEffect = GameObject.FindGameObjectWithTag("GoodWarp");
		warpEffect.transform.position = transform.position;
		warpEffect.GetComponent<ParticleSystem>().Play();

		spockAvatar = GameObject.FindGameObjectWithTag("SpockAvatar");

		spockAvatar.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Spok_0" + (blackHoleID + 1));
		spockAvatar.GetComponent<Image>().enabled = true;
		StartCoroutine(begToSpockGoAway());

		warpEffect.GetComponent<AudioSource>().Play();


		Debug.Log("success : " + enterprise.GetComponent<EnterpriseController>().currentId);

		gameController.GetComponent<LifeController>().increaseLife();

		if(blackHoleID == 8)
		{
			GameObject.FindGameObjectWithTag("WinScreen").GetComponent<Canvas>().enabled = true;
		}
	}

	IEnumerator begToSpockGoAway()
	{
		yield return new WaitForSeconds(1f);
		spockAvatar.GetComponent<Image>().enabled = false;
	}


	void fail (GameObject enterprise)
	{
		GameObject warpEffect = GameObject.FindGameObjectWithTag("BadWarp");
		warpEffect.transform.position = transform.position;
		warpEffect.GetComponent<ParticleSystem>().Play();
		Debug.Log("fail : " + enterprise.GetComponent<EnterpriseController>().currentId);

		gameController.GetComponent<LifeController>().decreaseLife();

	}

	void displayId ()
	{
	}

	void displaySolution()
	{
		risingText.GetComponent<RisingText> ().setup ("" + blackHoleID);
		Instantiate (risingText, transform.position + Vector3.down + Vector3.right * 2, Quaternion.identity);
	}


}
