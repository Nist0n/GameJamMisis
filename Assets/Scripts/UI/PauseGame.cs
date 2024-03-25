using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGadme : MonoBehaviour
{
    private bool _isPaused = false;
    [SerializeField] private GameObject canvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            Time.timeScale = 0;
            _isPaused = true;
            canvas.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _isPaused = false;
        canvas.SetActive(false);
    }
    
    public void ExitMenu()
    {
        Time.timeScale = 1;
        _isPaused = false;
        canvas.SetActive(false);
        SceneManager.LoadScene("Menu");
    }
}
