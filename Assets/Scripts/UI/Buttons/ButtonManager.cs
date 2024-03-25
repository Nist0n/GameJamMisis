using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene("House");
    }

    public void Exitmenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ExitTheHouse()
    {
        if (PlayerPrefs.GetInt("currentLoc") == 0) SceneManager.LoadScene("SampleScene");
        if (PlayerPrefs.GetInt("currentLoc") == 1) SceneManager.LoadScene("SampleScene 1");
        if (PlayerPrefs.GetInt("currentLoc") == 2) SceneManager.LoadScene("University");
        if (PlayerPrefs.GetInt("currentLoc") == 3) SceneManager.LoadScene("University 1");
    }

    public void Home()
    {
        SceneManager.LoadScene("House");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
    
}
