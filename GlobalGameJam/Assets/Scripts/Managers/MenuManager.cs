using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance = null;

    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject EndGameCanvas;
    public GameObject UiGameCanvas;

    public GameObject PauseCanvas;

    public AudioClip audioclipGameOver;
    private GameObject speakerGameOver;

    public GameObject TutoBox;

    public CanvasGroup MainMenuCanvasGroup;
    public CanvasGroup CreditsCanvasGroup;
    public CanvasGroup EndGameCanvasGroup;

    public float fadeInSpeed;
    public float fadeOutSpeed;

    public bool hasFinishedTuto = false;

    float delay = 0.5f;

    public bool isMessageBox = false;
    public bool isInMenu = false;
    public bool isInGame = false;



    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start()
    {

        StartCoroutine(fadeIn(MainMenuCanvasGroup, fadeInSpeed));
    }
	
	// Update is called once per frame
	void Update () {
        if (isMessageBox)
        {
            if(delay != 0)
              delay = Mathf.Max(delay - Time.deltaTime, 0f);
            if (delay == 0)
            {
                if (Input.GetButtonDown("A_button_1"))
                {

                    Application.LoadLevel("BossFeature");
                    TutoBox.SetActive(false);
                    isMessageBox = false;
                    isInMenu = false;
                    
                }
                else if (Input.GetButtonDown("B_button_1"))
                {

                    Application.LoadLevel("BossFeatureWithoutTuto");
                    TutoBox.SetActive(false);
                    isMessageBox = false;
                    isInMenu = false;
                    
                }
            }
            
        }

        if (Input.GetButtonDown("Start_button_1") && Application.loadedLevelName !="Menu" && !EndGameCanvas.activeInHierarchy)
        {
            Time.timeScale = 0;
            isInMenu = true;
            PauseCanvas.SetActive(true);

        }

    }

    public void OnClickPlay()
    {
        TutoBox.SetActive(true);
        isMessageBox = true;
        MainMenuCanvas.GetComponentInChildren<Button>().interactable = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Main_Menu()
    {

        Time.timeScale = 1;
        isInMenu = false;
        ChangeCanvas(MainMenuCanvasGroup, MainMenuCanvasGroup);
        Application.LoadLevel(0);
    }

    public void Main_Menu_From_Credit()
    {
        HideAll();
        MainMenuCanvas.SetActive(true);
        StartCoroutine(fadeIn(MainMenuCanvasGroup, fadeInSpeed));
        StartCoroutine(fadeOut(CreditsCanvasGroup));

    }

    public void TryAgain()
    {

        isInMenu = false;
        Application.LoadLevel(2);
    }

    public void ShowCredits()
    {
        HideAll();
        CreditsCanvas.SetActive(true);
        StartCoroutine(fadeIn(CreditsCanvasGroup, fadeInSpeed));
        StartCoroutine(fadeOut(MainMenuCanvasGroup));
    }


    //Valentin
    public void ShowEndGame(bool win)
    {

        HideAll();
        EndGameCanvas.SetActive(true);
        StartCoroutine(fadeIn(EndGameCanvasGroup, 0.014f));
        isInMenu = true;
        speakerGameOver = SoundManager.Instance.playSound(audioclipGameOver, 100);
        speakerGameOver.GetComponent<AudioSource>().loop = false;
        Invoke("PutPause", 2.5f);
       

        if (win)
        {
            EndGameCanvas.transform.FindChild("CanvasGroup").FindChild("WinText").GetComponent<Text>().text = "You defeated Warlord Paresh";
        }else
        {
            EndGameCanvas.transform.FindChild("CanvasGroup").FindChild("WinText").GetComponent<Text>().text = "You got defeated";
        }
    }

    public void Restart()
    {

        isInMenu = false;
        Time.timeScale = 1;
        if (hasFinishedTuto)
        {
            Application.LoadLevel("BossFeatureWithoutTuto");
            //Load scene boss
        }else
        {
            Application.LoadLevel("BossFeature");
        }
    }

    public void Resume()
    {

        PauseCanvas.SetActive(false);
        isInMenu = false;
        Time.timeScale = 1;
    }

    public void HideAll()
    {
        MainMenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
        EndGameCanvas.SetActive(false);
    }

    IEnumerator fadeIn(CanvasGroup currentCanva, float fadeInSpeed)
    {

        //yield return new WaitForSeconds(1f);
        while (currentCanva.alpha < 1.0f)
        {
            currentCanva.gameObject.SetActive(true);
            currentCanva.alpha += fadeInSpeed;
            yield return new WaitForSeconds(0.01f);
        }


    }
    IEnumerator fadeOut(CanvasGroup currentCanva)
    {

        while (currentCanva.alpha > 0.0f)
        {
            currentCanva.alpha -= 0.05f;
            currentCanva.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.01f);
        }
        currentCanva.gameObject.SetActive(false);

    }

    private void ChangeCanvas(CanvasGroup canvasOut, CanvasGroup canvasIn)
    {
        StartCoroutine(fadeOut(canvasOut));
        StartCoroutine(fadeIn(canvasIn, fadeInSpeed));
    }


    
    private void PutPause()
    {
        Time.timeScale = 0;
    }
    
    



}

