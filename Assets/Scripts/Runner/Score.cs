using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int ScoreInt;
    public Text ScoreText;
    
    public void ScorePlusOne()
    {
        ScoreInt++;
    }

    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
        if (ScoreInt == 10)
        {
            PlayerPrefs.SetInt("hapinessScore", PlayerPrefs.GetInt("hapinessScore") + 2);
            PlayerPrefs.SetInt("cloak", PlayerPrefs.GetInt("cloak") + 8);
            SceneManager.LoadScene("University 1");
        }
    }
}
