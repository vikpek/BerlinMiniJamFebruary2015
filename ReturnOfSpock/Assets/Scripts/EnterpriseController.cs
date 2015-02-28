using UnityEngine;
using System.Collections;

public class EnterpriseController : MonoBehaviour {
	public int currentId
	{
		get; set;
	}

	void Awake()
	{
		currentId = -1;
	}
}
