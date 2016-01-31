using UnityEngine;
using System.Collections;

public class HouseMusic : MonoBehaviour {

    public AudioClip audioclipMusic;

    private GameObject speakerMainMusic;

    // Use this for initialization
    void Start () {
        speakerMainMusic = SoundManager.Instance.playSound(audioclipMusic, 1);
        speakerMainMusic.GetComponent<AudioSource>().loop = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
