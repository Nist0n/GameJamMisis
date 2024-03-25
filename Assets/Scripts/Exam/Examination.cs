using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Examination : MonoBehaviour
{
    [SerializeField] private Animator diceAnim;
    [SerializeField] private Image[] frames;
    [SerializeField] private Image fail;
    [SerializeField] private Image success;
    [SerializeField] private Image badEnd;
    [SerializeField] private Image goodEnd;
    [SerializeField] private Image badEnd2;
    [SerializeField] private Image restart;
    [SerializeField] private Canvas canvas;
    [SerializeField] private AudioSource correctAudio;
    [SerializeField] private AudioSource inCorrectAudio;

    private int _attempts = 0;
    private int _correctAnswer = 0;

    private void Update()
    {
        if (_attempts == 2)
        {
            StartCoroutine(ClosePanel());
        }

        if (_correctAnswer == 2)
        {
            StartCoroutine(ClosePanel());
        }
    }
    
    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(4f);
        if (_correctAnswer < 2)
        {
            badEnd.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
        else
        {
            if (PlayerPrefs.GetInt("hapinessScore") == 0)
            {
                badEnd2.gameObject.SetActive(true);
                restart.gameObject.SetActive(true);
            }
            else
            {
                goodEnd.gameObject.SetActive(true);
                restart.gameObject.SetActive(true);
            }
        }
        canvas.gameObject.SetActive(false);
        _attempts = 0;
    }

    public void TryFortune()
    {
        int rand = Random.Range(1, 6);
        Debug.Log("rolling" + $"{rand}");
        Debug.Log(_attempts);
        if (PlayerPrefs.GetInt("learningScore") == 1)
        {
            if (_attempts != 3)
            {
                diceAnim.SetTrigger("rolling" + $"{rand}");
                Debug.Log(_attempts);
                Debug.Log("rolling" + $"{rand}");
                if (rand >= 6)
                {
                    correctAudio.PlayOneShot(correctAudio.clip);
                    Instantiate(success, frames[_attempts].transform.position, Quaternion.identity,
                        canvas.gameObject.transform);
                    _attempts++;
                    _correctAnswer++;
                }
                else
                {
                    inCorrectAudio.PlayOneShot(inCorrectAudio.clip);
                    Instantiate(fail, frames[_attempts].transform.position, Quaternion.identity,
                        canvas.gameObject.transform);
                    _attempts++;
                }
            }
        }
        if (PlayerPrefs.GetInt("learningScore") == 2)
        {
            if (_attempts != 3)
            {
                Debug.Log("rolling" + $"{rand}");
                Debug.Log(_attempts);
                diceAnim.SetTrigger("rolling" + $"{rand}");
                if (rand >= 5)
                {
                    correctAudio.PlayOneShot(correctAudio.clip);
                    Instantiate(success, frames[_attempts].transform.position, Quaternion.identity,
                        canvas.gameObject.transform);
                    _attempts++;
                    _correctAnswer++;
                }
                else
                {
                    inCorrectAudio.PlayOneShot(inCorrectAudio.clip);
                    Instantiate(fail, frames[_attempts].transform.position, Quaternion.identity,
                        canvas.gameObject.transform);
                    _attempts++;
                }
            }
        }
        if (PlayerPrefs.GetInt("learningScore") == 3)
        {
            if (_attempts != 3)
            {
                Debug.Log("rolling" + $"{rand}");
                Debug.Log(_attempts);
                diceAnim.SetTrigger("rolling" + $"{rand}");
                if (rand >= 4)
                {
                    correctAudio.PlayOneShot(correctAudio.clip);
                    Instantiate(success, frames[_attempts].transform.position, Quaternion.identity,
                        canvas.gameObject.transform);
                    _attempts++;
                    _correctAnswer++;
                }
                else
                {
                    inCorrectAudio.PlayOneShot(inCorrectAudio.clip);
                    Instantiate(fail, frames[_attempts].transform.position, Quaternion.identity,
                        canvas.gameObject.transform);
                    _attempts++;
                }
            }
        }
        if (PlayerPrefs.GetInt("learningScore") == 4)
        {
            if (_attempts != 3)
            {
                Debug.Log("rolling" + $"{rand}");
                Debug.Log(_attempts);
                diceAnim.SetTrigger("rolling" + $"{rand}");
                if (rand >= 3)
                {
                    correctAudio.PlayOneShot(correctAudio.clip);
                    Instantiate(success, frames[_attempts].transform.position, Quaternion.identity,
                        canvas.gameObject.transform);
                    _attempts++;
                    _correctAnswer++;
                }
                else
                {
                    inCorrectAudio.PlayOneShot(inCorrectAudio.clip);
                    Instantiate(fail, frames[_attempts].transform.position, Quaternion.identity,
                        canvas.gameObject.transform);
                    _attempts++;
                }
            }
        }
    }
}
