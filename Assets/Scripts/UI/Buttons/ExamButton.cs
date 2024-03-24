using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamButton : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Camera cameraForGame;
    private PlayerMove _playerMove;

    private void Start()
    {
        _playerMove = FindObjectOfType<PlayerMove>();
    }

    public void OnPress()
    {
        canvas.gameObject.SetActive(false);
        mainCamera.SetActive(false);
        cameraForGame.gameObject.SetActive(true);
        _playerMove.gameObject.transform.position = new Vector3(91f, -0.4f, -11f);
        _playerMove.gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
    }
}
