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
    
    [SerializeField] private AudioSource _sfxAudio;
    [SerializeField] private AudioClip _restartClip;
    [SerializeField] private AudioClip _winClip;

    private int maxStage = 1;
    private int curStage = 1;
    private int keyCount = 0;

    public bool IsPlayerDead { get; set; }

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
        IsPlayerDead = false;
        IsRestarted = true;
        GameManager.Instance.PlayOneShot(_restartClip);
        SceneManager.LoadScene("Stage" + curStage);
    }

    public void ClearStage()
    {
        if (curStage == maxStage)
        {
            OnClearGame?.Invoke();
            PlayOneShot(_winClip);
            return;
        }
        curStage++;
    }

    public void PlayOneShot(AudioClip clip)
    {
        _sfxAudio.PlayOneShot(clip);
    }
}
