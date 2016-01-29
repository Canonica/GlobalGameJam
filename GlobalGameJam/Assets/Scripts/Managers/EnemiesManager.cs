using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance = null;
    public List<Enemy> mEnemies;
    public int nbMaxEnemies;

    public GameObject prefabEnemy;

	void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        DontDestroyOnLoad(this);

        mEnemies = new List<Enemy>();
        Enemy[] casseCouilleDeUnity = FindObjectsOfType<Enemy>() as Enemy[];
        for(int i = 0; i < casseCouilleDeUnity.Length; i++)
        {
            mEnemies.Add(casseCouilleDeUnity[i]);
        }
    }
	
	void Update ()
    {

	}

}
