using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CollectiblesManager : MonoBehaviour 
{
	public bool[] mCollectibles; // bools checking if the collectibles are on/off

	void Awake () 
	{
		DontDestroyOnLoad(this); // makes sure this gameobject moves between the scenes
	}
}