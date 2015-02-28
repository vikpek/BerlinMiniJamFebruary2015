using UnityEngine;
using System.Collections;

public class EnterpriseController : MonoBehaviour {
	public int lastBlackHoleID
	{
		get; set;
	}

	void Awake()
	{
		lastBlackHoleID = -1;
	}
}
