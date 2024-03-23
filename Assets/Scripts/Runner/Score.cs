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
        if (ScoreInt == 1)
        {
            PlayerPrefs.SetInt("hapinessScore", PlayerPrefs.GetInt("hapinessScore") + 2);
            SceneManager.LoadScene(1);
        }
    }
}
