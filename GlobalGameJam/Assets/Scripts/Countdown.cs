using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {
	public float timer;
	public float countDown = 5;

    public int m_second = 59;
    public int m_minute = 0;
    private Text m_text;
    private bool isNowPlaying;

    private bool isLastMinutes = false;

	void Start () {
        isNowPlaying = false;
	}
    
	void Update() {
        if (!isNowPlaying && GameManager.instance.gamestate == GameManager.GameState.playing)
        {
           CDStart();
           isNowPlaying = true;
           
        }

        /*if (GameManager.instance.gamestate == GameManager.GameState.pause || GameManager.instance.gamestate == GameManager.GameState.endOfGame)
        {
            StopAllCoroutines();
            isNowPlaying = true;
        }
        else if (isNowPlaying)
        {
            isNowPlaying = false;
            StartCoroutine(StartCD());
        }*/
    }
    

    public void CDStart()
    {
       
        m_text = GetComponent<Text>();
        if(m_second < 10)
        {
            m_text.text = "0"+m_second.ToString();
        }
        else
        {
            m_text.text = m_second.ToString();
        }
        StartCoroutine(StartCD());
    }

    IEnumerator StartCD()
    {

        while((m_minute > 0 || m_second > 0) )
        {
                yield return new WaitForSeconds(1f);
                m_second -= 1;
                if (m_second == -1 && m_minute > 0)
                {
                    m_second = 59;
                    m_minute -= 1;
                }
                if (m_second < 10)
                {
                    m_text.text = "0" + m_second.ToString();
                }
                else
                {
                    m_text.text = m_second.ToString();
                }
                if (m_second <= 30 && isLastMinutes==false)
                {
                    isLastMinutes = true;
                }
        }
        yield return new WaitForSeconds(1f);
        GameManager.instance.EndOfGame();
    }

}


