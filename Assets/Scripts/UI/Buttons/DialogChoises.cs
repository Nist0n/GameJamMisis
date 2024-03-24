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
    [SerializeField] private Image _image;

    private DialogManager _dm;
    private PlayerMovement _player;

    public void HideChoise()
    {
        _gameObject.gameObject.SetActive(false);
        _canvas.gameObject.SetActive(true);
        _player.transform.position = new Vector3(-9f, 0f, 15f);
        Destroy(_image.gameObject);
    }

    private void Start()
    {
        _dm = GetComponentInParent<DialogManager>();
        _canvas.gameObject.SetActive(false);
        _player = FindObjectOfType<PlayerMovement>();
    }

    public void AnswerNo()
    {
        _gameObject.gameObject.SetActive(false);
        _player.enabled = true;
    }

    public void AnswerYes()
    {
        SceneManager.LoadScene("Main");
    }
}
