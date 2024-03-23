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
    public bool IsActive = false;

    private void Awake()
    {
        _dialogManager = FindObjectOfType<DialogManager>();
        _dialogs = FindObjectsOfType<Dialog>();
        _dialog = FindObjectOfType<Dialog>();
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if ((_dialog.gameObject.transform.position.x - _player.transform.position.x) < Distance && PlayerPrefs.GetInt("dtIsFirst") == 1)
        {
            _dialog.gameObject.GetComponent<Animator>().SetBool(Animator.StringToHash("LightDialog"), true);
        }

        if (IsActive)
        {
            Vector3 movement = new Vector3(_player.transform.position.x, 0f, _player.transform.position.z);
            movement.Normalize();
                    
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 20 * Time.deltaTime);
        }

        foreach (var dialog in _dialogs)
        {
            if (Vector3.Distance(dialog.gameObject.transform.position, _player.transform.position) < Distance)
            {
                if (Input.GetKeyDown(KeyCode.X) && !IsActive && PlayerPrefs.GetInt("dtIsFirst") == 1)
                {
                    _dialogManager.StartDialog(dialog);
                    IsActive = true;
                }
                else
                {
                    dialog.gameObject.GetComponent<Animator>().SetBool(Animator.StringToHash("LightDialog"), false);
                }
            }
        }
    }
}
