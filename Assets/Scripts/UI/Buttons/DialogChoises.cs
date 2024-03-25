using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogChoises : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Canvas scoreBoard;
    [SerializeField] private Image _image;
    private Music _music;

    private DialogManager _dm;
    private PlayerMovement _player;

    public void HideChoise()
    {
        PlayerPrefs.SetInt("currentLoc", PlayerPrefs.GetInt("currentLoc") + 1);
        _gameObject.gameObject.SetActive(false);
        _canvas.gameObject.SetActive(true);
        _player.transform.position = new Vector3(-9f, 0f, 15f);
        scoreBoard.gameObject.SetActive(false);
        Destroy(_image.gameObject);
    }

    private void Start()
    {
        _dm = GetComponentInParent<DialogManager>();
        _canvas.gameObject.SetActive(false);
        _player = FindObjectOfType<PlayerMovement>();
        _music = FindObjectOfType<Music>();
    }

    public void AnswerNo()
    {
        _gameObject.gameObject.SetActive(false);
        _player.enabled = true;
    }
    
    public void AnswerYes()
    {
        Destroy(_music.gameObject);
        PlayerPrefs.SetInt("currentLoc", PlayerPrefs.GetInt("currentLoc") + 1);
        SceneManager.LoadScene("Main");
    }

    public void Understand()
    {
        SceneManager.LoadScene("SampleScene 1");
        PlayerPrefs.SetInt("currentLoc", PlayerPrefs.GetInt("currentLoc") + 1);
    }
}
