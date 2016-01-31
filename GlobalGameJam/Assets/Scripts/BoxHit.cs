using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxHit : MonoBehaviour
{
    Player player;
    public AudioClip hit1;
    public AudioClip hit2;
    public AudioClip hit3;
    public AudioClip hit4;
    public AudioClip hit5;

    private GameObject speakerHit;

    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player") return;

        player.sizeBeforeHit = player.instanceEM.mEnemies.Count;
        if(other.tag == "Enemy")
        {
            speakerHit = SoundManager.Instance.RandomizeSfx(hit1, hit2, hit3, hit4, hit5);
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.mLife--;
            if (enemy.mLife < 1)
            {
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
                player.multiplierScore = 4;
            else if (addScore > 5000)
                player.multiplierScore = 3;
            else if (addScore > 1000)
                player.multiplierScore = 2;

            player.sizeBeforeHit = player.instanceEM.mEnemies.Count;

            player.score += addScore;
        }
    }

}
    