using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeManager : MonoBehaviour 
{
	public List<GameObject> mCollectiblesGo;
	GameObject mCollectiblesManager;

	void Start () 
	{
		mCollectiblesManager = GameObject.Find("HomeArenaManager"); // Looks for the "CollectiblesManager" game object

		if (mCollectiblesManager != null) // If "CollectiblesManager" exists do...
		{
			CheckForCollectibles();	
		}
	}
	

	void CheckForCollectibles() // Checks which collectibles are enabled, if any is enabled
	{
		CollectiblesManager mCollectiblesScript = mCollectiblesManager.GetComponent<CollectiblesManager>();

		for (int i = 0 ; i < mCollectiblesGo.Count ; i++)
		{
			if (mCollectiblesScript.mCollectibles[i] == true) // if the bool is active && the collectible is deactivated, then we activate the collectible
			{
				mCollectiblesGo[i].SetActive(true);
			}

			else 
			{
				print(i + " is inactive"); // can be removed
			}
		}
	}
}