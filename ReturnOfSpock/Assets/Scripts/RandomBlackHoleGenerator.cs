using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomBlackHoleGenerator : MonoBehaviour {

	GameObject[] blackHoles;
	List<int> randomNumbers;

	void Awake()
	{
		blackHoles = GameObject.FindGameObjectsWithTag("BlackHole");

		randomNumbers = new List<int>();
		for(int i = 0; i <= blackHoles.Length; i++)
		{
			randomNumbers.Add(i);
		}
	}


	void Start () {
		int tmpRandom;
		for(int i = 0; i<blackHoles.Length; i++)
		{
			blackHoles[i].GetComponent<BlackHoleController>().blackHoleID = randomNumbers[i];
		}
	}
}
