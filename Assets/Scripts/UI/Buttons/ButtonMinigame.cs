using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMinigame : MonoBehaviour
{
    public RectTransform Focus;
    private Animator _animator;
    private ScoreOfStates _player;
    [SerializeField] private GameObject _paper;
    [SerializeField] private Image[] _frames;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Image _fail;
    [SerializeField] private Image _success;
    private int _attempts = 0;
    public bool _isFirst = true;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        _player = FindObjectOfType<ScoreOfStates>();
    }

    private void Update()
    {
        if (_attempts == 2)
        {
            StartCoroutine(ClosePanel());
        }
    }

    IEnumerator ClosePanel()
    {
        yield return new WaitForSeconds(4f);
        _animator.gameObject.SetActive(false);
        _player.GetComponent<PlayerMovement>().enabled = true;
        _attempts = 0;
        _isFirst = false;
        canvas.gameObject.SetActive(true);
        PlayerPrefs.SetInt("cloak", PlayerPrefs.GetInt("cloak") + 8);
        SceneManager.LoadScene("University");
    }

    public void CheckPos()
    {
        if (Focus.position.y >= 520f && Focus.position.y <= 720f)
        {
            if (_attempts != 3)
            {
                Instantiate(_success, _frames[_attempts].transform.position, Quaternion.identity,
                    _animator.gameObject.transform);
                Instantiate(_paper, _player.transform.position, Quaternion.identity);
                _attempts++;
                PlayerPrefs.SetInt("hapinessScore", PlayerPrefs.GetInt("hapinessScore") + 1);
            }
        }
        else
        {
            if (_attempts != 3)
            {
                Instantiate(_fail, _frames[_attempts].transform.position, Quaternion.identity,
                    _animator.gameObject.transform);
                Vector3 pos = new Vector3(_player.transform.position.x, _player.transform.position.y + 4f,
                    _player.transform.position.z + 2f);
                _player.GetComponent<ThrowPaper>().ThrowPapers(pos);
                _attempts++;
            }
        }
    }
}
