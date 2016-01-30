using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance = null;
    public List<Enemy> mEnemies;
    public int nbMaxEnemies;

    public int nbMaxOrc;
    public int nbMaxGiant;

    public GameObject prefabEnemy;
    public GameObject prefabOrc;
    public GameObject prefabGiant;
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
        nbMaxOrc = 1 + (DayManager.instance.currentDay);
        nbMaxGiant = 1 + ((int)DayManager.instance.currentDay);
        StartCoroutine(spawnEnnemies(nbMaxEnemies));
    }

    public IEnumerator spawnEnnemies(int maxNbOFEnnemies)
    {

            
        while(GameManager.instance.gamestate == GameManager.GameState.playing)
        {
            if(DayManager.instance.currentDay >= 1)
            {
                for (int i = 0; i < nbMaxOrc; i++)
                {
                    int randomSpawn = (int)UnityEngine.Random.Range(1f, 4.99f);
                    float randomX;
                    Vector3 spawnPos;
                    switch (randomSpawn)
                    {
                        case 1:
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
                        default:
                            randomX = UnityEngine.Random.Range(mSpawnLeft.transform.localScale.x * 2, -mSpawnLeft.transform.localScale.x * 2);
                            spawnPos = new Vector3(mSpawnLeft.transform.position.y + mSpawnLeft.transform.position.x, randomX, mSpawnLeft.transform.position.z);
                            break;
                    }
                    yield return new WaitForSeconds(3 * delayBetweenEnnemies / (nbMaxEnemies - mEnemies.Count - 1));
                    GameObject newEnemy = Instantiate(prefabOrc, spawnPos, Quaternion.identity) as GameObject;
                    Enemy test = newEnemy.GetComponent<Enemy>();
                    mEnemies.Add(test);
                }
            }
            if (DayManager.instance.currentDay >= 1 )
            {
                for (int i = 0; i < nbMaxGiant; i++)
                {
                    int randomSpawn = (int)UnityEngine.Random.Range(1f, 4.99f);
                    float randomX;
                    Vector3 spawnPos;
                    switch (randomSpawn)
                    {
                        case 1:
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
                        default:
                            randomX = UnityEngine.Random.Range(mSpawnLeft.transform.localScale.x * 2, -mSpawnLeft.transform.localScale.x * 2);
                            spawnPos = new Vector3(mSpawnLeft.transform.position.y + mSpawnLeft.transform.position.x, randomX, mSpawnLeft.transform.position.z);
                            break;
                    }
                    yield return new WaitForSeconds(3 * delayBetweenEnnemies / (nbMaxEnemies - mEnemies.Count - 1));
                    GameObject newEnemy = Instantiate(prefabEnemy, spawnPos, Quaternion.identity) as GameObject;

                    Enemy test = prefabGiant.GetComponent<Enemy>();
                    mEnemies.Add(test);
                }
            }

            for (int i =0; i < maxNbOFEnnemies; i++)
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
                GameObject newEnemy = Instantiate(prefabEnemy, spawnPos, Quaternion.identity) as GameObject;
                Enemy  test = newEnemy.GetComponent<Enemy>();
                mEnemies.Add(test);
            }
            
        }
    }
}
