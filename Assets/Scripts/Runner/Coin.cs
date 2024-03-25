using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private Score _score;
    private void Update()
    {
        _score = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Score>();
        gameObject.transform.Rotate(0, 0, 0.5f);//rotate apple
    }

    private void OnTriggerEnter(Collider other)
    {
        _score.ScorePlusOne();
        Destroy(gameObject);//apple
    }
}
