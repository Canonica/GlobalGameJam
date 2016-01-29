using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    EnemiesManager instanceEM;
    public float angleHit;

    void Start ()
    {
        instanceEM = EnemiesManager.instance;
    }
	
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.K))
        {
            Hit();
        }
	}

    void Hit()
    {
        Vector3 hitDirection = Input.mousePosition - transform.position;
        Enemy enemy;
        Vector3 v;
        float produitScalaire;
        float angle;
        for (int i = 0; i < instanceEM.mEnemies.Count; i++)
        {
            enemy = instanceEM.mEnemies[i];
            v = enemy.transform.position - transform.position;
            produitScalaire = hitDirection.x * v.x + hitDirection.y * v.y + hitDirection.z * v.z;
            angle = Mathf.Acos(produitScalaire / (hitDirection.magnitude * v.magnitude));
            
            if (Mathf.Sqrt(angle* angle) < Mathf.Sqrt(angleHit * angleHit))
            {
                instanceEM.mEnemies.Remove(enemy);
                enemy.gameObject.SetActive(false);
                i--;
            }
        }
    }
}
