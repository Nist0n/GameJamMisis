using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForExamApleExam : MonoBehaviour
{
    private DialogManagerFor _DialogManager;

    [SerializeField] private GameObject _choice;
    [SerializeField] private GameObject[] _choices;
    private ScoreOfStates _player;
    private CheckForExample _check;

    private bool _isOpen = false;

    private void Start()
    {
        _DialogManager = GetComponentInChildren<DialogManagerFor>();
        _check = FindObjectOfType<CheckForExample>();
        _player = FindObjectOfType<ScoreOfStates>();
    }

    private void Update()
    {
        if (_DialogManager.DialogIsOver && !_isOpen)
        {
            ShowChoise2();
            _isOpen = false;
        }
    }

    private void ShowChoise2()
    {
        if (_DialogManager.DialogIsOver)
        {
            Debug.Log(gameObject.name);
            _isOpen = true;
            foreach (var choise in _choices)
            {
                choise.SetActive(true);
                _choice.SetActive(true);
                _player.GetComponent<PlayerMove>().enabled = false;
            }
            _DialogManager.DialogIsOver = false;
        }
    }
}
