using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogChoises : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Canvas _canvas;

    public void HideChoise()
    {
        _gameObject.gameObject.SetActive(false);
        _canvas.gameObject.SetActive(true);
    }

    private void Start()
    {
        _canvas.gameObject.SetActive(false);
    }

    public void AnswerNo()
    {
        _gameObject.gameObject.SetActive(false);
    }
}
