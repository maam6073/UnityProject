using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManagers : MonoBehaviour
{
    public static bool GameIsOver;
    public GameObject gameOverUI;
    public GameObject gamesuccess;
    private void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
            return;
        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }
        if (PlayerStats.LIFE <= 0)
        {
            EndGame();
        }


    }
    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }
}