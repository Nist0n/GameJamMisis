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

    public void ExitTheHouse()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Home()
    {
        PlayerPrefs.SetInt("dtIsFirst", 0);
        SceneManager.LoadScene("House");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
    
}
