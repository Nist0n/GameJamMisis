using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMinigame : MonoBehaviour
{
    public RectTransform Focus;
    private Animator _animator;
    private PlayerMovement _player;
    [SerializeField] private GameObject _paper;
    [SerializeField] private Image[] _frames;
    [SerializeField] private Image _fail;
    [SerializeField] private Image _success;
    private int _attempts = 0;
    public bool _isFirst = true;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        _player = FindObjectOfType<PlayerMovement>();
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
        _player.enabled = true;
        _attempts = 0;
        _isFirst = false;
    }

    public void CheckPos()
    {
        if (Focus.position.y >= 520f && Focus.position.y <= 720f)
        {
            if (_attempts != 3)
            {
                Instantiate(_success, _frames[_attempts].transform.position, Quaternion.identity,
                    _animator.gameObject.transform);
                _animator.SetTrigger("success");
                Instantiate(_paper, _player.transform.position, Quaternion.identity);
                _attempts++;
            }
        }
        else
        {
            if (_attempts != 3)
            {
                Instantiate(_fail, _frames[_attempts].transform.position, Quaternion.identity,
                    _animator.gameObject.transform);
                _animator.SetTrigger("failure");
                Vector3 pos = new Vector3(_player.transform.position.x, _player.transform.position.y + 4f,
                    _player.transform.position.z + 2f);
                _player.GetComponent<ThrowPaper>().ThrowPapers(pos);
                _attempts++;
            }
        }
    }
}
