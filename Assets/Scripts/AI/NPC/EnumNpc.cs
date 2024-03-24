using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumNpc : MonoBehaviour
{
    public _npc npc;
    [SerializeField] private GameObject _choice;
    [SerializeField] private GameObject[] _choices;
    [SerializeField] private GameObject[] _choicesVictor;
    [SerializeField] private GameObject[] _choicesExam;
    private ScoreOfStates _player;
    private CheckForExample _check;

    private void Start()
    {
        _check = FindObjectOfType<CheckForExample>();
        _player = FindObjectOfType<ScoreOfStates>();
    }

    public enum _npc
    {
        Victor,
        Bahilovich,
        Exam
    }
    
    public void DisplayChoises()
    {
        if (npc == _npc.Bahilovich)
        {
            Debug.Log("bahil");
            foreach (var choise in _choices)
            {
                choise.SetActive(true);
                _choice.SetActive(true);
                _player.GetComponent<PlayerMovement>().enabled = false;
            }
        }
        
        if (npc == _npc.Victor)
        {
            Debug.Log("victor");
            foreach (var choise in _choicesVictor)
            {
                choise.SetActive(true);
                _choice.SetActive(true);
                _player.GetComponent<PlayerMovement>().enabled = false;
            }
        }
    }
}
