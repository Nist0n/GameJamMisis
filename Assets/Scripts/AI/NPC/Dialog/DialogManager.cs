using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private Animator _scoreBoard;

    public Text DialogText;
    public Animator DialogBorderAnim;
    public DialogTrigger _dt;
    
    private Queue<string> _sentences = new Queue<string>();
    private ScoreOfStates _player;

    private bool _senteceIsOver;

    public bool DialogIsOver = false;

    private void Start()
    {
        _dt = GetComponentInParent<DialogTrigger>();
        DialogBorderAnim = GetComponent<Animator>();
        _player = FindObjectOfType<ScoreOfStates>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _senteceIsOver == true)
        {
            DisplayNextSentence();
        }
    }

    public void StartDialog(Dialog dialog)
    {
        _scoreBoard.SetBool("isActived", false);
        
        _player.GetComponent<PlayerMovement>().enabled = false;

        DialogBorderAnim.SetBool(Animator.StringToHash("Start"), true);
        
        _sentences.Clear();
        
        DialogText.text = "";

        foreach (var sentence in dialog.Sentences)
        {
            _sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        _senteceIsOver = false;
        
        if (_sentences.Count == 0)
        {
            EndDialog();
            DialogIsOver = true;
            return;
        }

        string sentence = _sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        DialogText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            DialogText.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        
        _senteceIsOver = true;
    }

    private void EndDialog()
    {
        _player.GetComponent<PlayerMovement>().enabled = true;
        DialogBorderAnim.SetBool(Animator.StringToHash("Start"), false);
        _dt.IsActive = false;
        _scoreBoard.SetBool("isActived", true);
    }
}
