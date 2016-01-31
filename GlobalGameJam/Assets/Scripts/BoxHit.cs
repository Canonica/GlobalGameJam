using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BoxHit : MonoBehaviour
{
    Player player;

	#region Particles
	[Header("Death")]

	[Header("====- Particles -=====")]
	public GameObject mEnemyDeathParticle;

	[Header("Combo")]
	public List<GameObject> mComboParticles;
	public GameObject mAxeAttack;
	#endregion

    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    void OnTriggerEnter(Collider other)
    {
		Instantiate(mAxeAttack, this.transform.position, Quaternion.identity);

        if (other.tag == "Player") return;

        player.sizeBeforeHit = player.instanceEM.mEnemies.Count;
        if(other.tag == "Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.mLife--;
            if (enemy.mLife < 1)
            {
				//int i = Mathf.RoundToInt(Random.Range(0, 2));
				//print("i: " + i);
				Instantiate(mEnemyDeathParticle, this.transform.position, Quaternion.identity);
                player.instanceEM.mEnemies.Remove(enemy);
                enemy.gameObject.SetActive(false);
            }

            player.instanceEM.mEnemies.Remove(enemy);
            switch(other.name)
            {
                case "Gobelin":
                    EnemiesManager.instance.currentNbEnemies--; break;
                case "Troll":
                    EnemiesManager.instance.currentNbEnemies -= 2; break;
                case "Giant":
                    EnemiesManager.instance.currentNbEnemies -= 3; break;
            }
            enemy.gameObject.SetActive(false);
        }
        
        


        //Scoring
        if (Time.time > player.timeLastKill + player.timeMultiplier)
            player.multiplierScore = 1; 

        if (player.sizeBeforeHit - player.instanceEM.mEnemies.Count > 0)
        {
            int addScore = 0;
            addScore += GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().score * (player.sizeBeforeHit - player.instanceEM.mEnemies.Count);
            addScore += player.bonusMultiKill * (player.sizeBeforeHit - player.instanceEM.mEnemies.Count - 1);
            addScore *= player.multiplierScore;

            if (addScore > 20000)
			{
                player.multiplierScore = 4;
				Instantiate(mComboParticles[2], this.transform.position, Quaternion.identity);
			}

            else if (addScore > 5000)
			{
                player.multiplierScore = 3;
				Instantiate(mComboParticles[1], this.transform.position, Quaternion.identity);
			}

            else if (addScore > 1000)
			{
                player.multiplierScore = 2;
				Instantiate(mComboParticles[0], this.transform.position, Quaternion.identity);
			}

            player.sizeBeforeHit = player.instanceEM.mEnemies.Count;

            player.score += addScore;
        }
    }
}