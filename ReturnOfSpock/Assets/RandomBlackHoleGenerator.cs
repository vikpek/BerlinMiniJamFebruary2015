using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomBlackHoleGenerator : MonoBehaviour {

	GameObject[] blackHoles;
//	Dictionary 

	void Awake()
	{
		blackHoles = GameObject.FindGameObjectsWithTag("BlackHole");
	}


	void Start () {
		foreach(GameObject blackHole in blackHoles)
		{
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
