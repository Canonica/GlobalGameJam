using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour
{
    public EnemiesManager instanceEM;
    public GameManager instanceGM;
    public float mLife;
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
    public bool mCanAttack;
    public float attackDelay;
    public GameObject box;

    public Text scoreText;

    public GameObject blockLeftPlayer;
    public GameObject blockRightPlayer;

    public GameObject blockTopArena;
    public GameObject blockLeftArena;
    public GameObject blockRightArena;
    public GameObject blockDownArena;

    public AudioClip grunt1;
    public AudioClip grunt2;
    public AudioClip grunt3;
    public AudioClip grunt4;
    public AudioClip grunt5;
    public AudioClip grunt6;

    public AudioClip swoosh1;
    public AudioClip swoosh2;
    public AudioClip swoosh3;
    public AudioClip swoosh4;
    public AudioClip swoosh5;

    private GameObject speakerGrunt;
    private GameObject speakerSwoosh;

    void Start ()
    {
        instanceEM = EnemiesManager.instance;
        instanceGM = GameManager.instance;
        timeLastKill = Time.time;
        mCanAttack = true;
        attackDelay = 0.5f;
    }
    void Update()
    {
        if (GameManager.instance.gamestate == GameManager.GameState.playing)
        {

            if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("L_YAxis_1") < -0.2)
            {
                this.GetComponent<Animator>().SetTrigger("triggerMove");
                if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("L_XAxis_1") < -0.2)
                {
                    if(transform.position.y < blockTopArena.transform.position.y && transform.position.x > blockLeftArena.transform.position.x)
                    {
                        Move(new Vector3(-1 / Mathf.Sqrt(2), 1 / Mathf.Sqrt(2), 0));
                    }
                    
                    transform.rotation = new Quaternion(0, 180, 0, 1);
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("L_XAxis_1") > 0.2)
                {
                    if (transform.position.y < blockTopArena.transform.position.y && transform.position.x < blockRightArena.transform.position.x)
                    {
                        Move(new Vector3(1 / Mathf.Sqrt(2), 1 / Mathf.Sqrt(2), 0));
                    }
                    transform.rotation = new Quaternion(0, 0, 0, 1);
                }
                else
                {
                    if (transform.position.y < blockTopArena.transform.position.y)
                    {
                        Move(new Vector3(0, 1, 0));
                    }
                        
                }
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("L_YAxis_1") > 0.2)
            {
                this.GetComponent<Animator>().SetTrigger("triggerMove");
                if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("L_XAxis_1") < -0.2)
                {
                    if (transform.position.y > blockDownArena.transform.position.y && transform.position.x > blockLeftArena.transform.position.x)
                    {
                        Move(new Vector3(-1 / Mathf.Sqrt(2), -1 / Mathf.Sqrt(2), 0));
                    }
                    transform.rotation = new Quaternion(0, 180, 0, 1);
                }
                else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("L_XAxis_1") > 0.2)
                {
                    if (transform.position.y > blockDownArena.transform.position.y && transform.position.x < blockRightArena.transform.position.x)
                    {
                        Move(new Vector3(1 / Mathf.Sqrt(2), -1 / Mathf.Sqrt(2), 0));
                    }
                    transform.rotation = new Quaternion(0, 0, 0, 1);
                }
                else
                {
                    if (transform.position.y > blockDownArena.transform.position.y)
                    {
                        Move(new Vector3(0, -1, 0));
                    }
                }
            }
            else if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("L_XAxis_1") < -0.2)
            {
                this.GetComponent<Animator>().SetTrigger("triggerMove");
                if (transform.position.x > blockLeftArena.transform.position.x)
                {
                    Move(new Vector3(-1, 0, 0));
                }
                transform.rotation = new Quaternion(0, 180, 0, 1);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("L_XAxis_1") > 0.2)
            {
                this.GetComponent<Animator>().SetTrigger("triggerMove");
                if (transform.position.x < blockRightArena.transform.position.x)
                {
                    Move(new Vector3(1, 0, 0));
                }
                transform.rotation = new Quaternion(0, 0, 0, 1);
            }
        }

        if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("A_button_0")) && mCanAttack)
        {
            StartCoroutine(Attack());
        }

        if (GameManager.instance.gamestate == GameManager.GameState.house)
        {
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("L_XAxis_1") < -0.2)
            {
                transform.localRotation = new Quaternion(0f, 180f, 0f, 1);
                
                if(transform.position.x > blockLeftPlayer.transform.position.x)
                {
                    Move(new Vector3(-1, 0, 0));
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("L_XAxis_1") > 0.2)
            {
                transform.localRotation = new Quaternion(0f, 0f, 0f, 1);
                if (transform.position.x < blockRightPlayer.transform.position.x)
                {
                    Move(new Vector3(1, 0, 0));
                }
            }
        }
    }

    /*void HitKeyBoard()
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
                    enemy.mLife--;
                    if(enemy.mLife < 1)
                    {
                        instanceEM.mEnemies.Remove(enemy);
                        enemy.gameObject.SetActive(false);
                        i--;
                    }
                }
            }
        }

        //Scoring
        if (Time.time > timeLastKill + timeMultiplier)
            multiplierScore = 1;
        
        if (sizeBeforeHit - instanceEM.mEnemies.Count > 0)
        {
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
    }*/

    public void Move(Vector3 direction)
    {
        //  transform.LookAt(transform.position + direction * movementSpeed);
        transform.position += direction * movementSpeed*50  *Time.deltaTime;
    }

    public void receiveDamage(int damage)
    {
        speakerGrunt = SoundManager.Instance.RandomizeSfx(grunt1, grunt2, grunt3, grunt4, grunt5, grunt6);
        mLife -= damage;
        if(mLife < 1)
        {
            instanceGM.GameOver();
        }
    }
    IEnumerator Attack()
    {

        mCanAttack = false;
        this.GetComponent<Animator>().SetTrigger("triggerAttack");
        speakerSwoosh = SoundManager.Instance.RandomizeSfx(swoosh1, swoosh2, swoosh3, swoosh4, swoosh5);
        GameObject obj = Instantiate(box, transform.GetChild(0).transform.position, Quaternion.identity) as GameObject;
        obj.transform.parent = transform;
        yield return new WaitForSeconds(attackDelay);
        this.GetComponent<Animator>().ResetTrigger("triggerAttack");
        Destroy(obj.gameObject);

        mCanAttack = true;
    }
}
