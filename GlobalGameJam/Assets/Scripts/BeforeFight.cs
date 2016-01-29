using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BeforeFight : MonoBehaviour
{

    public int m_second = 3;

    private Text text;
    private Countdown timer;
    private float alpha;
    public bool ready=false;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(StartCDBeforeFight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartCDBeforeFight()
    {
        float timer = 5;
        while (m_second >= 0)
        {
            timer += Time.deltaTime * 500;
            yield return new WaitForSeconds(1f);
            if(m_second == 3)
            {
                
                text.CrossFadeAlpha(1f, 0f, false);
                text.CrossFadeAlpha(0.1f, 0.9f, false);
            }
            else if (m_second == 2)
            {
                text.CrossFadeAlpha(1f, 0f, false);
                text.CrossFadeAlpha(0.1f, 0.9f, false);
            }
            else if (m_second == 1)
            {
                text.CrossFadeAlpha(1f, 0f, false);
                text.CrossFadeAlpha(0.1f, 0.9f, false);
            }
            text.fontSize += Mathf.RoundToInt(timer);
            text.text = m_second.ToString();
            alpha = GetComponent<CanvasGroup>().alpha;
            m_second--;

        }
        text.CrossFadeAlpha(1f, 0.2f, false);
        
        text.text = "Clean";
        text.color = Color.red;
        if (text.text == "Clean")
        {
            text.CrossFadeAlpha(1f, 0f, false);
            text.CrossFadeAlpha(0f, 1f, false);
        }
        ready = true;
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.gamestate = GameManager.GameState.playing;
    }
}
