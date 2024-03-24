using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Learning : MonoBehaviour
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
        if (PlayerPrefs.GetInt("hapinessScore") < 2)
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

    public void Learn()
    {
        if (PlayerPrefs.GetInt("hapinessScore") >= 2)
        {
            PlayerPrefs.SetInt("hapinessScore", PlayerPrefs.GetInt("hapinessScore") - 2);
            PlayerPrefs.SetInt("learningScore", PlayerPrefs.GetInt("learningScore") + 1);
        }
    }
}
