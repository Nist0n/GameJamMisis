using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogFix : MonoBehaviour
{
    private DialogManagerFor _dialogManager;
    private Dialog[] _dialogs;
    private Dialog _dialog;
    private GameObject _player;
    public float Distance;
    public bool IsActive = false;

    private void Awake()
    {
        _dialogManager = GetComponentInChildren<DialogManagerFor>();
        _dialogs = FindObjectsOfType<Dialog>();
        _dialog = FindObjectOfType<Dialog>();
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        Dialog dialogObject = null;
        float tempDistance = Distance;
        foreach (var dialog in _dialogs)
        {
            var distanceObject = Vector3.Distance(dialog.gameObject.transform.position, _player.transform.position);
            if (distanceObject < Distance)
            {
                if (distanceObject < tempDistance)
                {
                    tempDistance = distanceObject;
                    dialogObject = dialog;
                }
            }
        }
        
        if (dialogObject != null)
        {
            if (Input.GetKeyDown(KeyCode.X) && !IsActive && PlayerPrefs.GetInt("dtIsFirst") == 1)
            {
                _dialogManager.StartDialog(dialogObject);
                IsActive = true;
            }
            else
            {
                dialogObject.gameObject.GetComponent<Animator>().SetBool(Animator.StringToHash("LightDialog"), true);
            }
        }

        if (IsActive)
        {
            Vector3 movement = new Vector3(_player.transform.position.x, 0f, _player.transform.position.z);
            movement.Normalize();
                    
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 80 * Time.deltaTime);
        }

        foreach (var dialog in _dialogs)
        {
            if (dialog != dialogObject && PlayerPrefs.GetInt("dtIsFirst") == 1)
            {
                dialog.gameObject.GetComponent<Animator>().SetBool(Animator.StringToHash("LightDialog"), false);
            }
        }
    }
}
