using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int mLife;
    public float mMovementSpeed;
    public GameObject mPlayer;

	void Start ()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        Physics.IgnoreCollision(this.GetComponent<Collider>(), GetComponent<Collider>());

    }
	
	void Update ()
    {
        float step = mMovementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, mPlayer.transform.position, step);
	}
}
