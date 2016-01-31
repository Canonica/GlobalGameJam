using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemiesManager : MonoBehaviour
{
    public static EnemiesManager instance = null;
    public List<Enemy> mEnemies;
    public int nbMaxEnemies;
    public int currentNbEnemies;

    public GameObject prefabOrc;
    public GameObject prefabGobelin;
    public GameObject prefabGiant;
    public bool isSpawning;

    public float delayBetweenEnnemies;
    public int nbMaxGiant;
    public int nbMaxOrc;
    public int nbMaxGobelin;

    public GameObject mSpawnTop;
    public GameObject mSpawnLeft;
    public GameObject mSpawnRight;
    public GameObject mSpawnDown;

    public AudioClip gobelin1;
    public AudioClip gobelin2;
    public AudioClip gobelin3;
    public AudioClip gobelin4;
    public AudioClip gobelin5;
    public AudioClip gobelin6;

    private GameObject speakerGobelin;

    public AudioClip giant1;
    public AudioClip giant2;
    public AudioClip giant3;

    private GameObject speakerGiant;

    public AudioClip troll1;
    public AudioClip troll2;
    public AudioClip troll3;
    public AudioClip troll4;
    public AudioClip hit5;

    private GameObject speakerTroll;

    public Countdown CD;


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
        if(GameManager.instance.gamestate == GameManager.GameState.playing)
        {
            if (!isSpawning)
            {
                startSpawnEnnemies();
                isSpawning = true;
            }
        }
    }

    void startSpawnEnnemies()
    {
        nbMaxGobelin = 12 + DayManager.instance.currentDay * 2;
        nbMaxOrc = 6 + DayManager.instance.currentDay;
        nbMaxGiant = 3 + (int)(DayManager.instance.currentDay / 2);
        StartCoroutine(spawnEnnemies());  
    }

    Vector3 getSpawnPos()
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
        return spawnPos;
    }

    public IEnumerator spawnEnnemies()
    {
        nbMaxEnemies = nbMaxGobelin + 2 * nbMaxOrc + 3 * nbMaxGiant * (2 -  CD.m_second/30);
        currentNbEnemies = mEnemies.Count;
        Vector3 spawnPos;
        GameObject newEnemy;
        while (nbMaxEnemies - currentNbEnemies >= 3)
        {
            yield return new WaitForSeconds(3 * delayBetweenEnnemies / (nbMaxEnemies - mEnemies.Count - 1));
            if (GameManager.instance.gamestate == GameManager.GameState.playing)
            {
                int rand = (int)UnityEngine.Random.Range(0, 3);
                spawnPos = getSpawnPos();
                switch (rand)
                {
                    case 0:
                        newEnemy = Instantiate(prefabGobelin, spawnPos, Quaternion.identity) as GameObject;
                        float randSpeed = UnityEngine.Random.Range(0.85f, 1.11f);
                        newEnemy.GetComponent<Enemy>().mMovementSpeed *= randSpeed;
                        currentNbEnemies += 1;
                        break;
                    case 1:
                        newEnemy = Instantiate(prefabOrc, spawnPos, Quaternion.identity) as GameObject;
                        currentNbEnemies += 2;
                        break;
                    default:
                        newEnemy = Instantiate(prefabGiant, spawnPos, Quaternion.identity) as GameObject;
                        currentNbEnemies += 3;
                        break;
                }
                Enemy test = newEnemy.GetComponent<Enemy>();
                mEnemies.Add(test);
            }
        }

        if(nbMaxEnemies - currentNbEnemies > 0)
        {
            yield return new WaitForSeconds(3 * delayBetweenEnnemies / (nbMaxEnemies - mEnemies.Count - 1));
            spawnPos = getSpawnPos();
            switch (nbMaxEnemies - currentNbEnemies)
            {
                case 1:
                    newEnemy = Instantiate(prefabGobelin, spawnPos, Quaternion.identity) as GameObject;
                    float randSpeed = UnityEngine.Random.Range(0.85f, 1.11f);
                    newEnemy.GetComponent<Enemy>().mMovementSpeed *= randSpeed;
                    break;
                case 2:
                    newEnemy = Instantiate(prefabOrc, spawnPos, Quaternion.identity) as GameObject;
                    break;
                case 3:
                    newEnemy = Instantiate(prefabGiant, spawnPos, Quaternion.identity) as GameObject;
                    break;
            }
            currentNbEnemies = nbMaxEnemies;
            isSpawning = false;
        }
        isSpawning = false;
    }
}



