using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if(GameManager.instance.gamestate == GameManager.GameState.house && Vector3.Distance(transform.position, player.transform.position) <1.5f)
        {
            StartCoroutine(CanDoAction());
           transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
	}

    IEnumerator CanDoAction()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DoAction());
        }
        yield return new WaitForEndOfFrame();
    }

    IEnumerator DoAction()
    {
        //
        if(transform.name == "Hache")
        {
            Application.LoadLevel("Game");
        }
        yield return new WaitForEndOfFrame();
    }
}
