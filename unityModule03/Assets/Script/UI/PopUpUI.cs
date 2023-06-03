using System;
using System.Collections;
using System.Collections.Generic;
using Module02;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpUI : MonoBehaviour
{
    private bool _isPoppedUp = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject confirmMenu;

    private void Awake()
    {
        pauseMenu = transform.GetChild(0).gameObject;
        pauseMenu.SetActive(false);
        
        confirmMenu = transform.GetChild(1).gameObject;
        confirmMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPoppedUp)
            {
                confirmMenu.SetActive(false);
                OnClickResume();
            }
            else
            {
                _isPoppedUp = true;
                GameManager.Instance.PauseGame();
                pauseMenu.SetActive(true);
            }
        }
    }

    public void OnClickResume()
    {
        _isPoppedUp = false;
        GameManager.Instance.ResumeGame();
        pauseMenu.SetActive(false);
    }

    public void OnClickQuit()
    {
        confirmMenu.SetActive(true);
    }

    public void OnClickYes()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickNo()
    {
        confirmMenu.SetActive(false);
    }
}
