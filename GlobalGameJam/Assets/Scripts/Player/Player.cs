using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    EnemiesManager instanceEM;
    public float angleHit;
    public float rangeHit;
    public float movementSpeed;
    public int multiplierScore;
    public int sizeBeforeHit;
    public int score;
    public int scoreByKill;
    public int bonusMultiKill;
    public float timeLastKill;
    public float timeMultiplier;

    void Start ()
    {
        instanceEM = EnemiesManager.instance;
        timeLastKill = Time.time;
    }
	
	void Update ()
    {
	    if(Input.GetMouseButton(0))
        {
            Hit();
        }
        if(Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            Move(new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move(new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            Move(new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move(new Vector3(1, 0, 0));
        }
    }

    void Hit()
    {
        sizeBeforeHit = instanceEM.mEnemies.Count;
        //Si on a touche (la chatte a la voisine !!) ou pas
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y,Camera.main.transform.position.z);
        Ray ray;
        ray = Camera.main.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            
        }
        Vector3 hitDirection = new Vector3(hit.point.x, hit.point.y, 0) - transform.position;
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
                if((enemy.transform.position-transform.position).magnitude < rangeHit)
                {
                    instanceEM.mEnemies.Remove(enemy);
                    enemy.gameObject.SetActive(false);
                    i--;
                }
            }
        }

        //Scoring
        if (Time.time > timeLastKill + timeMultiplier)
            multiplierScore = 1;
        
        if (sizeBeforeHit - instanceEM.mEnemies.Count > 0)
        {
            Debug.Log("Yolo");
            int addScore = 0;
            addScore += scoreByKill * (sizeBeforeHit - instanceEM.mEnemies.Count);
            addScore += bonusMultiKill * (sizeBeforeHit - instanceEM.mEnemies.Count - 1);
            addScore *= multiplierScore;

            if (addScore > 20000)
                multiplierScore = 4;
            else if (addScore > 5000)
                multiplierScore = 3;
            else if (addScore > 1000)
                multiplierScore = 2;

            sizeBeforeHit = instanceEM.mEnemies.Count;

            score += addScore;
        }
        Debug.Log(score);
    }

    public void Move(Vector3 direction)
    {
        transform.LookAt(transform.position + direction * movementSpeed);
        transform.position += direction * movementSpeed;
    }
}
