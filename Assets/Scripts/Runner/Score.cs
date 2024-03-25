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
    private Music _music;

    private void Start()
    {
        _music = FindObjectOfType<Music>();
    }

    public void ScorePlusOne()
    {
        ScoreInt++;
        GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
    }

    private void Update()
    {
        ScoreText.text = ScoreInt.ToString();
        if (ScoreInt == 10)
        {
            Destroy(_music.gameObject);
            PlayerPrefs.SetInt("hapinessScore", PlayerPrefs.GetInt("hapinessScore") + 2);
            PlayerPrefs.SetInt("cloak", PlayerPrefs.GetInt("cloak") + 8);
            SceneManager.LoadScene("University 1");
        }
    }
}
