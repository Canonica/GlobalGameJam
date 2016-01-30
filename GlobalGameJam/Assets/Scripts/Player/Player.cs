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
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.transform.position.z);
        Ray ray;
        ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            
        }
        Debug.Log(hit.point);

        Vector3 hitDirection = new Vector3(hit.point.x, hit.point.y, 0) - transform.position;
        
        Enemy enemy;
        Vector3 v;
        float produitScalaire;
        float angle;
        for (int i = 0; i < instanceEM.mEnemies.Count; i++)
        {
            enemy = instanceEM.mEnemies[i];
            v = enemy.transform.position - transform.position;
            //Debug.Log("u : " + hitDirection);
            //Debug.Log("v : " + v);
            produitScalaire = hitDirection.x * v.x + hitDirection.y * v.y + hitDirection.z * v.z;
            //Debug.Log("prodScal : " + produitScalaire);
            angle = Mathf.Acos(produitScalaire / (hitDirection.magnitude * v.magnitude));
            //Debug.Log("angle : " + angle);

            if (Mathf.Sqrt(angle* angle) < Mathf.Sqrt(angleHit * angleHit))
            {
                instanceEM.mEnemies.Remove(enemy);
                enemy.gameObject.SetActive(false);
                i--;
            }
        }
    }
}
