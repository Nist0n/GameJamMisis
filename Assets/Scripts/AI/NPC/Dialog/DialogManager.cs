using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text DialogText;
    public Animator DialogBorderAnim;
    
    private Queue<string> _sentences = new Queue<string>();
    private DialogTrigger _dt;
    private PlayerMovement _player;
    private bool _senteceIsOver;
    [SerializeField] private GameObject _choice;
    [SerializeField] private GameObject[] _choices;

    private void Start()
    {
        _dt = GetComponentInParent<DialogTrigger>();
        DialogBorderAnim = GetComponent<Animator>();
        _player = FindObjectOfType<PlayerMovement>();
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
        _player.enabled = false;

        DialogBorderAnim.SetBool(Animator.StringToHash("Start"), true);
        
        _sentences.Clear();
        
        DialogText.text = "";

        foreach (var sentence in dialog.Sentences)
        {
            _sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        _senteceIsOver = false;
        
        if (_sentences.Count == 0)
        {
            DisplayChoises();
            EndDialog();
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
        _player.enabled = true;
        DialogBorderAnim.SetBool(Animator.StringToHash("Start"), false);
        _dt.IsActive = false;
    }

    private void DisplayChoises()
    {
        foreach (var choise in _choices)
        {
            choise.SetActive(true);
            _choice.SetActive(true);
        }
    }
}
