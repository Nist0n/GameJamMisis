using System;
using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class Starte : MonoBehaviour
{
    [SerializeField] private NPCConversation _npc;
    [SerializeField] private Animator _animator;
    [SerializeField] private Canvas _canvas;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                ConversationManager.Instance.StartConversation(_npc);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool(Animator.StringToHash("LightDialog"), false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool(Animator.StringToHash("LightDialog"), true);
        }
    }
}
