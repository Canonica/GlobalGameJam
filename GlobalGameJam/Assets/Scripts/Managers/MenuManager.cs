using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance = null;

    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject EndGameCanvas;
    public GameObject HowToPlayCanvas;
    public GameObject UiGameCanvas;

    public GameObject PauseCanvas;

    public AudioClip audioclipGameOver;
    private GameObject speakerGameOver;


    public CanvasGroup MainMenuCanvasGroup;
    public CanvasGroup HowToPlayCanvasGroup;
    public CanvasGroup CreditsCanvasGroup;
    public CanvasGroup EndGameCanvasGroup;

    public float fadeInSpeed;
    public float fadeOutSpeed;

    float delay = 0.5f;

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


    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        isInMenu = false;
        Application.LoadLevel("Game");
    }

    public void HowToPlay()
    {
        HideAll();
        HowToPlayCanvas.SetActive(true);
        StartCoroutine(fadeIn(HowToPlayCanvasGroup, fadeInSpeed));
        StartCoroutine(fadeOut(MainMenuCanvasGroup));
    }
    
    public void Main_Menu()
    {
        GameManager.instance.gamestate = GameManager.GameState.menu;
        Time.timeScale = 1;
        isInMenu = false;
        ChangeCanvas(MainMenuCanvasGroup, MainMenuCanvasGroup);
        Application.LoadLevel("MainMenu");
    }

    public void MainMenuFromCredit()
    {
        HideAll();
        MainMenuCanvas.SetActive(true);
        StartCoroutine(fadeIn(MainMenuCanvasGroup, fadeInSpeed));
        StartCoroutine(fadeOut(CreditsCanvasGroup));
    }

    public void MainMenuFromHowToPlay()
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
       


    }

    public void Restart()
    {

        isInMenu = false;
        Time.timeScale = 1;
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
        HowToPlayCanvas.SetActive(false);
        CreditsCanvas.SetActive(false);
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

