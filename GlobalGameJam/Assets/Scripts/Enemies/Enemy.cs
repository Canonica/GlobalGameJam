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

	void Start ()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(mPlayer);
    }
	
	void Update ()
    {
        float step = mMovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mPlayer.transform.position, step);
        Quaternion rotation = Quaternion.LookRotation
             (mPlayer.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        if ( (mPlayer.transform.position-transform.position).magnitude < rangeHitPlayer)
        {
            mPlayer.GetComponent<Player>().receiveDamage(mDamage);
        }
	}

    public int getScore()
    {
        return score;
    }
}
