using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMinigame : MonoBehaviour
{
    public RectTransform Focus;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }

    public void CheckPos()
    {
        if (Focus.position.y >= 490f && Focus.position.y <= 770f)
        {
            _animator.SetTrigger("success");
        }
        else
        {
            _animator.SetTrigger("failure");
        }
    }

    private void Update()
    {
        Debug.Log(Focus.position.y);
    }
}
