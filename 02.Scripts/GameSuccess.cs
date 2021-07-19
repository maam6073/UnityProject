using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSuccess : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene("01.Lobby");
    }
}
