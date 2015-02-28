using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeController : MonoBehaviour {
	int lifeValue;

	Text lifeText;

	// Use this for initialization
	void Start () {
		lifeValue = 5;
		lifeText = GameObject.FindGameObjectWithTag("Lifes").GetComponent<Text>();
	}

	public void increaseLife()
	{
		lifeValue++;
		lifeText.text = lifeValue + "";
	}

	public void decreaseLife()
	{
		lifeValue--;
		lifeText.text = lifeValue + "";
	}
}
