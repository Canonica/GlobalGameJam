using UnityEngine;
using System.Collections;

public class DestroyByTimeSound : MonoBehaviour {
    private float time;
	// Use this for initialization
	void Start () {
        time = GetComponent<AudioSource>().clip.length;
	}
	
	// Update is called once per frame
	void Update () {
        if(!GetComponent<AudioSource>().loop == true && gameObject)
        {
            Destroy(gameObject, time);
        }
        
	}
}
