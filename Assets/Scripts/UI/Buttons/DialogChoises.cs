using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogChoises : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Canvas _canvas;
    private PlayerMovement _player;

    public void HideChoise()
    {
        _gameObject.gameObject.SetActive(false);
        _canvas.gameObject.SetActive(true);
        _player.transform.position = new Vector3(-9f, 0f, 15f);
    }

    private void Start()
    {
        _canvas.gameObject.SetActive(false);
        _player = FindObjectOfType<PlayerMovement>();
    }

    public void AnswerNo()
    {
        _gameObject.gameObject.SetActive(false);
        _player.enabled = true;
    }
}
