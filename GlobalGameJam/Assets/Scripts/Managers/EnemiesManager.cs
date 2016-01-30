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
    public bool isSpawning;

    public float delayBetweenEnnemies;

    public GameObject mSpawnTop;
    public GameObject mSpawnLeft;
    public GameObject mSpawnRight;
    public GameObject mSpawnDown;

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
        isSpawning = false;
        delayBetweenEnnemies = 1f;
    }
	
	void Update ()
    {
        if (!isSpawning && GameManager.instance.gamestate == GameManager.GameState.playing)
        {
            startSpawnEnnemies();
            isSpawning = true;
        }

    }

    void startSpawnEnnemies()
    {
        nbMaxEnemies = 12 + (DayManager.instance.currentDay * 2);
        StartCoroutine(spawnEnnemies(nbMaxEnemies));
    }

    IEnumerator spawnEnnemies(int maxNbOFEnnemies)
    {
        while(GameManager.instance.gamestate == GameManager.GameState.playing)
        {
            for(int i =0; i < maxNbOFEnnemies; i++)
            {
                int randomSpawn = (int)UnityEngine.Random.Range(1f, 4.99f);
                float randomX;
                Vector3 spawnPos;
                switch (randomSpawn)
                {
                    case 1 :
                        randomX = UnityEngine.Random.Range(mSpawnTop.transform.localScale.x * 2, -mSpawnTop.transform.localScale.x * 2);
                        spawnPos = new Vector3(randomX, mSpawnTop.transform.position.y, mSpawnTop.transform.position.z);
                        break;
                    case 2:
                        randomX = UnityEngine.Random.Range(mSpawnDown.transform.localScale.x * 2, -mSpawnDown.transform.localScale.x * 2);
                        spawnPos = new Vector3(randomX, mSpawnDown.transform.position.y, mSpawnDown.transform.position.z);
                        break;
                    case 3:
                        randomX = UnityEngine.Random.Range(mSpawnRight.transform.localScale.x * 2, -mSpawnRight.transform.localScale.x * 2);
                        spawnPos = new Vector3(mSpawnRight.transform.position.y + mSpawnRight.transform.position.x, randomX, mSpawnRight.transform.position.z);
                        break;
                    default :
                        randomX = UnityEngine.Random.Range(mSpawnLeft.transform.localScale.x * 2, -mSpawnLeft.transform.localScale.x * 2);
                        spawnPos = new Vector3(mSpawnLeft.transform.position.y + mSpawnLeft.transform.position.x, randomX, mSpawnLeft.transform.position.z);
                        break;

                }
                
                
                yield return new WaitForSeconds(3*delayBetweenEnnemies / (nbMaxEnemies - mEnemies.Count-1));
                Enemy newEnemy = Instantiate(prefabEnemy, spawnPos, Quaternion.identity) as Enemy;
                mEnemies.Add(newEnemy);
            }
            
        }
        Debug.Log(nbMaxEnemies);
    }


}
