using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int mLife;
    public float mMovementSpeed;
    public GameObject mPlayer;
    public float rangeHitPlayer;
    public int mDamage;

	void Start ()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(mPlayer);
    }
	
	void Update ()
    {
        float step = mMovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mPlayer.transform.position, step);
        if( (mPlayer.transform.position-transform.position).magnitude < rangeHitPlayer)
        {
            mPlayer.GetComponent<Player>().receiveDamage(mDamage);
        }
	}
}
