using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CollectiblesManager : MonoBehaviour 
{
    static private CollectiblesManager mInstance;
    public HomeManager instanceHM;

    public bool[] mCollectibles; // bools checking if the collectibles are on/off

	void Awake () 
	{
		//DontDestroyOnLoad(this); // makes sure this gameobject moves between the scenes

        if (mInstance == null)
        {
            mInstance = this;
        }

        mCollectibles = new bool[8];
    }

    void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            instanceHM = HomeManager.instance;
        }
    }

    static public CollectiblesManager instance
    {
        get
        {
            return mInstance;
        }
    }
}