using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomeManager : MonoBehaviour 
{
	public List<GameObject> mCollectiblesGo;
	GameObject mCollectiblesManager;
    static private HomeManager mInstance;

    void Awake () 
	{
        if (mInstance == null)
        {
            mInstance = this;
        }

        mCollectiblesManager = GameObject.Find("HomeArenaManager"); // Looks for the "CollectiblesManager" game object
    }

    static public HomeManager instance
    {
        get
        {
            return mInstance;
        }
    }


    void CheckForCollectibles() // Checks which collectibles are enabled, if any is enabled
	{
		CollectiblesManager mCollectiblesScript = mCollectiblesManager.GetComponent<CollectiblesManager>();

		for (int i = 0 ; i < mCollectiblesGo.Count ; i++)
		{
			if (mCollectiblesScript.mCollectibles[i] == true)
			{
				mCollectiblesGo[i].SetActive(true);
			}
		}
	}
}