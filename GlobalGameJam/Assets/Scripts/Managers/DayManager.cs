using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DayManager : MonoBehaviour {
    public static DayManager instance = null;

    public CanvasGroup mAllCanvasGroupDay;
    public CanvasGroup mCanvasGroupDay;

    public int currentDay;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void OnLevelWasLoaded()
    {
        if (Application.loadedLevelName == "House")
        {
            mAllCanvasGroupDay = GameObject.FindGameObjectWithTag("groupAllDay").GetComponent<CanvasGroup>();
            mCanvasGroupDay = GameObject.FindGameObjectWithTag("groupDay").GetComponent<CanvasGroup>();
            ShowDay();
            HomeManager.instance.ActiveCollectible();

        }


    }
    // Use this for initialization
    void Start () {
        currentDay = 1;
    }
	
	// Update is called once per frame
	void Update () {
	
        
	}

    

    private void ShowDay()
    {
        mAllCanvasGroupDay.gameObject.SetActive(true);
        mAllCanvasGroupDay.alpha = 1;
        StartCoroutine(fadeInDay(mCanvasGroupDay));
        mAllCanvasGroupDay.gameObject.GetComponentInChildren<Text>().text = "Day " + currentDay;
    }

    IEnumerator fadeInDay(CanvasGroup currentCanva)
    {
        yield return new WaitForSeconds(0.5f);
        while (currentCanva.alpha < 1.0f)
        {
            currentCanva.gameObject.SetActive(true);
            currentCanva.alpha += 0.02f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(1.0f);
        StartCoroutine(fadeOutDay(mAllCanvasGroupDay, currentCanva));
    }

    IEnumerator fadeOutDay(CanvasGroup currentCanva, CanvasGroup mCanvasGroupDay)
    {
        while (mCanvasGroupDay.alpha > 0.0f)
        {
            mCanvasGroupDay.alpha -= 0.03f;
            mCanvasGroupDay.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.01f);
        }

        while (currentCanva.alpha > 0.0f)
        {
            currentCanva.alpha -= 0.02f;
            currentCanva.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.01f);
        }
        currentCanva.gameObject.SetActive(false);
    }
}


