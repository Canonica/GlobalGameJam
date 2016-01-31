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
                enemy.isDeath = true;
                StartCoroutine(death(enemy));
            }

        }


        //Scoring

        if (player.sizeBeforeHit - player.instanceEM.mEnemies.Count > 0)
        {
            int addScore = 0;
            addScore += GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().score * (player.sizeBeforeHit - player.instanceEM.mEnemies.Count);
            addScore += player.bonusMultiKill * (player.sizeBeforeHit - player.instanceEM.mEnemies.Count - 1);
            addScore *= player.multiplierScore;
            player.pointsToMultiplier += GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>().score * (player.sizeBeforeHit - player.instanceEM.mEnemies.Count);
            player.pointsToMultiplier += player.bonusMultiKill * (player.sizeBeforeHit - player.instanceEM.mEnemies.Count - 1);
            player.pointsToMultiplier *= player.multiplierScore;

            if (player.pointsToMultiplier > 20000)
                player.multiplierScore = 4;
            else if (player.pointsToMultiplier > 5000)
                player.multiplierScore = 3;
            else if (player.pointsToMultiplier > 1000)
                player.multiplierScore = 2;

            player.sizeBeforeHit = player.instanceEM.mEnemies.Count;

            player.score += addScore;
        }
    }

    IEnumerator death(Enemy enemy)
    {
        player.timeLastKill = Time.time;
        switch (enemy.name)
        {
            case "Gobelin":
                EnemiesManager.instance.currentNbEnemies--; break;
            case "Troll":
                EnemiesManager.instance.currentNbEnemies -= 2; break;
            case "Giant":
                EnemiesManager.instance.currentNbEnemies -= 3; break;
        }
       
        player.instanceEM.mEnemies.Remove(enemy);
        yield return new WaitForEndOfFrame();
    }

}
    