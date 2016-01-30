using UnityEngine;
using System.Collections;

public class GameInit : MonoBehaviour 
{
	#region Init
	public static bool mHasInitOnce;

	[Header("Collectibles Manager prefab")]
	public GameObject mCollectiblesManager;

	[Header("The ChangeScene prefab")]
	public GameObject mChangeScene;

	[Header("How many collectibles are in the game ?")]
	public int mNumberOfCollectibles;
	#endregion 


	void Awake () 
	{
		if (mHasInitOnce == false)
		{
			mHasInitOnce = true; // makes sure the gameobjects will only spawn once

			GameObject collectiblesManagerInst = Instantiate(mCollectiblesManager, Vector3.zero, Quaternion.identity) as GameObject;
			collectiblesManagerInst.name = "HomeArenaManager";
			collectiblesManagerInst.GetComponent<CollectiblesManager>().mCollectibles = new bool[mNumberOfCollectibles];

			GameObject sceneChanger = Instantiate(mChangeScene, Vector3.zero, Quaternion.identity) as GameObject;
			sceneChanger.name = "ChangeScene";
		}

		else 
		{
			this.gameObject.SetActive(false); // deactivates this gameobject
		}
	}
}