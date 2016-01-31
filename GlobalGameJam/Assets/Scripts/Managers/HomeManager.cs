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

    public void ActiveCollectible()
    {
        switch (DayManager.instance.currentDay)
        {
            case 1:
                mCollectiblesGo[13].SetActive(true);
                break;
            case 2:
                mCollectiblesGo[0].SetActive(true);
                break;
            case 3:
                mCollectiblesGo[1].SetActive(true);
                break;
            case 4:
                mCollectiblesGo[2].SetActive(true);
                break;
            case 5:
                mCollectiblesGo[3].SetActive(true);
                break;
            case 6:
                mCollectiblesGo[4].SetActive(true);
                break;
            case 7:
                mCollectiblesGo[5].SetActive(true);
                break;
            case 8:
                mCollectiblesGo[6].SetActive(true);
                break;
            case 9:
                mCollectiblesGo[7].SetActive(true);
                break;
            case 10:
                mCollectiblesGo[8].SetActive(true);
                break;

            case 11:
                mCollectiblesGo[9].SetActive(true);
                break;

            case 12:
                mCollectiblesGo[10].SetActive(true);
                mCollectiblesGo[11].SetActive(true);
                break;
            case 13:
                mCollectiblesGo[12].SetActive(true);
                break;
        }
    }
}