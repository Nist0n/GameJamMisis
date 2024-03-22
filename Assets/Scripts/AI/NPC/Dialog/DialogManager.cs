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

    private void Start()
    {
        DialogBorderAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialog(Dialog dialog)
    {
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
        if (_sentences.Count == 0)
        {
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
    }

    private void EndDialog()
    {
        DialogBorderAnim.SetBool(Animator.StringToHash("Start"), false);
    }
}
