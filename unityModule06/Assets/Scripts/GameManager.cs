using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance => _instance;
    public bool IsRestarted { get; set; }

    public Action OnAlertTarget;
    public Action OnCaughtTarget;
    public Action OnClearGame;

    private int maxStage = 1;
    private int curStage = 1;
    private int keyCount = 0;

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

        IsRestarted = false;
    }

    public bool IsCollectedAllKeys() => keyCount >= 3;
    public void CollectKey() => keyCount++;

    public void RestartStage()
    {
        IsRestarted = true;
        SceneManager.LoadScene("Stage" + curStage);
    }

    public void ClearStage()
    {
        if (curStage == maxStage)
        {
            OnClearGame?.Invoke();
            return;
        }
        curStage++;
    }
}
