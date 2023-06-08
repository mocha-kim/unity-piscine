using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public Action OnAlertTarget;
    public Action OnCaughtTarget;

    private int maxStage = 1;
    private int curStage = 1;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void RestartStage() => SceneManager.LoadScene("Stage" + curStage);

    public void ClearStage()
    {
        if (curStage == 1)
        {
            // SceneManager.LoadScene("");
        }
    }
}
