using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SleepGo : MonoBehaviour
{
    private Button _button;
    private Image _image;

    private void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        if (PlayerPrefs.GetInt("cloak") != 24)
        {
            _button.enabled = false;
            _image.color = new Color(1, 1, 1, 0.3f);
        }
        else
        {
            _button.enabled = true;
            _image.color = new Color(1, 1, 1, 1);
        }
    }

    public void Sleep()
    {
        if (PlayerPrefs.GetInt("cloak") == 24)
        {
            PlayerPrefs.SetInt("cloak", 8);
        }
    }
}
