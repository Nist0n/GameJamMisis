using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class Start2 : MonoBehaviour
{
    [SerializeField] private NPCConversation _npc;
    [SerializeField] private Animator _animator;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _gameObject;

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
            _canvas.gameObject.SetActive(true);
            _gameObject.SetActive(true);
            _animator.SetBool(Animator.StringToHash("LightDialog"), false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _gameObject.SetActive(false);
            _canvas.gameObject.SetActive(false);
            _animator.SetBool(Animator.StringToHash("LightDialog"), true);
        }
    }
}
