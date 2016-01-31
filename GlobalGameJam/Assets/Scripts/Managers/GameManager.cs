﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject panelPause;
    public Text playerName;
    public enum GameState { menu, pause, playing, endOfGame, beforePlay, house };
    public int goodScoreDayOne;

    public GameObject CanvasEndGameWin;
    public GameObject CanvasEndGameLoose;

    public GameState gamestate;
    #region Singleton
    static private GameManager s_Instance;
    #endregion
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
        gamestate = GameState.menu;
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {

            Invoke("DestroyAllMonsters", 0.5f);
        }

        if(level == 2)
        {
            CanvasEndGameWin = GameObject.FindGameObjectWithTag("CanvasEndGameWin");
            CanvasEndGameLoose = GameObject.FindGameObjectWithTag("CanvasEndGameLoose");
            CanvasEndGameWin.SetActive(false);
            CanvasEndGameLoose.SetActive(false);
        }
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

    public void EndOfGame(int scorePlayer)
    {
        GameManager.instance.gamestate = GameManager.GameState.endOfGame;
        if (scorePlayer >= goodScoreDayOne * Mathf.Pow(1.3f, DayManager.instance.currentDay))

        {
            CollectiblesManager.instance.mCollectibles[DayManager.instance.currentDay%4] = true;
            StartCoroutine(ShowEndCanvasWin());
        }
        
    }

    public void LoadHouse()
    {
        GameManager.instance.gamestate = GameManager.GameState.house;
        DayManager.instance.currentDay++;
        Application.LoadLevel("House");
    }


    public void GameOver()
    {

    }

    void DestroyAllMonsters()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

    IEnumerator ShowEndCanvasWin()
    {
        Debug.Log("Win");
        CanvasEndGameWin.SetActive(true);
        CanvasEndGameWin.GetComponentInChildren<ShowRecompense>().Show(DayManager.instance.currentDay);
        yield return new WaitForSeconds(3.0f);
        LoadHouse();
    }

    IEnumerator ShowEndCanvasLoose()
    {
        Debug.Log("Loose");
        CanvasEndGameLoose.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        LoadHouse();
    }

}