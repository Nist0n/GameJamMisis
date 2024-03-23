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

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
        _player = FindObjectOfType<PlayerMovement>();
    }

    public void CheckPos()
    {
        if (Focus.position.y >= 520f && Focus.position.y <= 720f)
        {
            _animator.SetTrigger("success");
            Instantiate(_paper, _player.transform.position, Quaternion.identity);
        }
        else
        {
            _animator.SetTrigger("failure");
            Vector3 pos = new Vector3(_player.transform.position.x, _player.transform.position.y + 4f,
                _player.transform.position.z + 2f);
            _player.GetComponent<ThrowPaper>().ThrowPapers(pos);
        }
    }
}
