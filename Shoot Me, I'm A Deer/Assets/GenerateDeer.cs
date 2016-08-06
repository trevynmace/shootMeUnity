﻿using UnityEngine;
using System.Collections;

public class GenerateDeer : MonoBehaviour 
{
	GameObject deer1;
	GameObject deer2;
	GameObject deer3;
	GameObject deer4;
	System.Collections.Generic.Dictionary<string, GameObject> dict;
	int nextActionTime = 5;
	int period = 5;

	// Use this for initialization
	void Start () 
	{
		deer1 = GameObject.Find ("deer1");
		deer2 = GameObject.Find ("deer2");
		deer3 = GameObject.Find ("deer3");
		deer4 = GameObject.Find ("deer4");
		dict = new System.Collections.Generic.Dictionary<string, GameObject>();

		AddDeerToDict ();

		ActuallyStart ();
	}

	void ActuallyStart()
	{
		HideAllDeer ();

		System.Random random = new System.Random ();
		string num = random.Next (1, 5).ToString ();
		string deerName = "deer" + num;
		GameObject activeDeer = dict [deerName];

		activeDeer.transform.position = GetNewLocation ();

		activeDeer.SetActive (true);
	}

	Vector3 GetNewLocation()
	{
		System.Random random = new System.Random ();
		var newXLocation = random.Next (Bounds.xAxisMin, Bounds.xAxisMax + 1);
		var newYLocation = random.Next (Bounds.yAxisMin, Bounds.yAxisMax + 1);
		return new Vector3 (newXLocation, newYLocation, 0);
	}

	void AddDeerToDict()
	{
		dict.Add ("deer1", deer1);
		dict.Add ("deer2", deer2);
		dict.Add ("deer3", deer3);
		dict.Add ("deer4", deer4);
	}

	void HideAllDeer()
	{
		deer1.SetActive (false);
		deer2.SetActive (false);
		deer3.SetActive (false);
		deer4.SetActive (false);
	}

	// Update is called once per frame
	void Update () 
	{
		period = GetTimeUntilNextDeerSpawn ();

		if (Time.time > nextActionTime) 
		{
			nextActionTime = (int)Time.time + period;
			ActuallyStart ();
		}
	}

	int GetTimeUntilNextDeerSpawn()
	{
		System.Random random = new System.Random ();
		return random.Next (5, 12);
	}
}

public struct Bounds
{
	public static int xAxisMin { get{ return -8; } }
	public static int xAxisMax { get{ return 8; } }
	public static int yAxisMin { get{ return -3;} }
	public static int yAxisMax { get{ return 3;} }
}