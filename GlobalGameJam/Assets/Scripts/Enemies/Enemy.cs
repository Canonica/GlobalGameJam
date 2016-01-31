using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int mLife;
    public float mMovementSpeed;
    public GameObject mPlayer;
    public float rangeHitPlayer;
    public int mDamage;
    public int score;
    public bool isDeath;

	void Start ()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        isDeath = false;
    }
	
	void Update ()
    {

        if ((mPlayer.transform.position - transform.position).magnitude < rangeHitPlayer)
        {
            mPlayer.GetComponent<Player>().receiveDamage(mDamage);
        }

        float step;
        if (!isDeath)
        {
            step = mMovementSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, mPlayer.transform.position, step);
        }
        else
        {
            step = mMovementSpeed * Time.deltaTime * 10  ;
            transform.position = Vector3.MoveTowards(transform.position,(transform.position- mPlayer.transform.position)*10 + transform.position, step);
            Invoke("Death", 0.2f);
        }

        if(mPlayer.transform.position.x > transform.position.x)
        {
            transform.rotation = new Quaternion(0, 0, 0, 1);
        }
        else
        {
            transform.rotation = new Quaternion(0, 180, 0, 1);
        }
	}

    public int getScore()
    {
        return score;
    }

    /*void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

    }*/

    public void Death()
    {
        Destroy(this.gameObject);
    }
}
