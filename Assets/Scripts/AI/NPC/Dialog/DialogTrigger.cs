using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private DialogManager _dialogManager;
    private Dialog[] _dialogs;
    private Dialog _dialog;
    private GameObject _player;
    public float Distance;

    private void Awake()
    {
        _dialogManager = FindObjectOfType<DialogManager>();
        _dialogs = FindObjectsOfType<Dialog>();
        _dialog = FindObjectOfType<Dialog>();
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if ((_dialog.gameObject.transform.position.x - _player.transform.position.x) < Distance)
        {
            _dialog.gameObject.GetComponent<Animator>().SetBool(Animator.StringToHash("LightDialog"), true);
        }

        foreach (var dialog in _dialogs)
        {
            if (Vector3.Distance(dialog.gameObject.transform.position, _player.transform.position) < Distance)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    _dialogManager.StartDialog(dialog);
                }
                else
                {
                    dialog.gameObject.GetComponent<Animator>().SetBool(Animator.StringToHash("LightDialog"), false);
                }
            }
        }
    }
}
