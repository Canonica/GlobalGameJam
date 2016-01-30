using UnityEngine;
using System.Collections;

public class TemporaryActivateBool : MonoBehaviour 
{
	/* 
	 * This script is simply used to check if it is possible to change the booleans of the collectibles manager
	 * from an external script.
	 * 
	 * It should be removed when we will have a true way to earn collectibles.
	 * Though, it may be ok as a base for now.
	 */

	public GameObject mCollectiblesManager;
	CollectiblesManager mRefToCollecScript;

	void Start () 
	{
		mCollectiblesManager = GameObject.Find("HomeArenaManager"); // Looks for the "CollectiblesManager" game object
		mRefToCollecScript = mCollectiblesManager.GetComponent<CollectiblesManager>();

		if (mCollectiblesManager != null) // If "CollectiblesManager" exists do...
		{
			StartCoroutine(ChangeCollectibleBool());
		}
	}
	
	public IEnumerator ChangeCollectibleBool() // Later, I suppose we could use a simple function instead of a co-routine
	{
		yield return new WaitForSeconds(1);

		mRefToCollecScript.mCollectibles[1] = true;
	}
}