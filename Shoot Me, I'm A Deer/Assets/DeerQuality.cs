using UnityEngine;
using System.Collections;

public class DeerQuality : MonoBehaviour 
{
	GameObject activeDeer;
	GameObject speechBubble;
	SpriteRenderer render;

	public void GenerateData(GameObject deer)
	{
		Physics.queriesHitTriggers = true;
		activeDeer = deer;

		speechBubble = GameObject.Find ("speechBubble");
		render = speechBubble.GetComponentInChildren<SpriteRenderer> ();
		render.enabled = false;
	}

	//show text "Shoot me! I'm a deer!"
	void OnMouseEnter()
	{
		Vector3 location = activeDeer.transform.position;
		speechBubble.transform.position = new Vector3 (location.x, location.y + 0.7f, location.z);
		render.enabled = true;
	}

	void OnMouseExit()
	{
		render.enabled = false;
	}

	//show the deer as 'shot' and set to inactive
	void OnMouseDown()
	{
		switch (activeDeer.name) 
		{
		case "deer1":
			ReplaceWithDeadDeer (1);
			break;
		case "deer2":
			ReplaceWithDeadDeer (2);
			break;
		case "deer3":
			ReplaceWithDeadDeer (3);
			break;
		case "deer4":
			ReplaceWithDeadDeer (4);
			break;
		}
	}

	void ReplaceWithDeadDeer (int number)
	{
		var activeDeerPos = activeDeer.transform.position;
		Vector3 pos = new Vector3 (activeDeerPos.x, activeDeerPos.y, activeDeerPos.z);

		activeDeer.SetActive (false);

		switch (number) 
		{
		case 1:
			CreateDeadDeer ("deadDeer1", pos);
			break;
		case 2:
			CreateDeadDeer ("deadDeer2", pos);
			break;
		case 3:
			CreateDeadDeer ("deadDeer3", pos);
			break;
		case 4:
			CreateDeadDeer ("deadDeer4", pos);
			break;
		}
	}

	void CreateDeadDeer(string deadDeerName, Vector3 position)
	{
		GameObject deadDeer = GameObject.Find (deadDeerName);
		deadDeer.transform.position = position;
		deadDeer.GetComponentInChildren<SpriteRenderer> ().enabled = true;

		render.enabled = false;
	}

	// Use this for initialization
	void Start () 
	{	

	}

	// Update is called once per frame
	void Update () 
	{

	}
}