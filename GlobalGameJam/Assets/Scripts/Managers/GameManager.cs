using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panelPause;
    public Text playerName;
    public enum GameState { menu, pause, playing, endOfGame, beforePlay };

    public GameState gamestate;
    #region Singleton
    static private GameManager s_Instance;

    static public GameManager instance
    {
        get
        {
            return s_Instance;
        }
    }
    void Awake()
    {
        if (s_Instance == null)
            s_Instance = this;
    }
    #endregion
    void Start()
    {
        gamestate = GameState.menu;
    }
    void Update()
    {
        if (GameManager.instance.gamestate == GameManager.GameState.pause)
        {
            //panelPause.SetActive(true);
        }
        else
        {
            //panelPause.SetActive(false);
        }
    }

    public void EndOfGame()
    {
        DayManager.instance.currentDay++;
        Application.LoadLevel("House");
    }


}