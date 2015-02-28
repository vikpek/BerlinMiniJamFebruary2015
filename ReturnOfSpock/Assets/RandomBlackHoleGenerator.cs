using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomBlackHoleGenerator : MonoBehaviour {

	GameObject[] blackHoles;
	List<Integer> froms;
	List<Integer> tos;

	void Awake()
	{
		blackHoles = GameObject.FindGameObjectsWithTag("BlackHole");
		//initial fill
		for(int i = 0; blackHoles.Length; i++)
		{
			froms.Add(i);
			tos.Add(i);
		}
	}


	void Start () {
		foreach(GameObject blackHole in blackHoles)
		{

		for(int i = 0; blackHoles.Length; i++)
		{
//			blackHoles[i].GetComponent<BlackHoleController>().
		}
//			blackHole.GetComponent<BlackHoleController>().blackHoleID
//			blackHole.GetComponent<BlackHoleController>().previousBlackHole = froms[
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
