using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Examen : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Image image;
    private bool _isTime;

    private void Update()
    {
        if (PlayerPrefs.GetInt("cloak") == 8)
        {
            image.gameObject.SetActive(true);
            _isTime = true;
        }
        else
        {
            image.gameObject.SetActive(false);
            _isTime = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.X) && PlayerPrefs.GetInt("cloak") == 8)
            {
                SceneManager.LoadScene("Exam");
                PlayerPrefs.SetInt("dtIsFirst", 1);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && _isTime)
        {
            animator.SetBool("inRange", true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && _isTime)
        {
            animator.SetBool("inRange", false);
        }
    }
}
