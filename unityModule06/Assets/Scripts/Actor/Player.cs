using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _caughtIndex;
    private Animator _animator;
    private AudioSource _audio;

    [SerializeField] private AudioClip _faintClip;

    private WaitForSeconds _wait = new WaitForSeconds(3f);

    private void Awake()
    {
        _caughtIndex = Animator.StringToHash("caught");
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        GameManager.Instance.OnCaughtTarget += OnCaught;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCaughtTarget -= OnCaught;
    }

    private void OnCaught()
    {
        _animator.SetTrigger(_caughtIndex);
        GameManager.Instance.IsPlayerDead = true;
        StartCoroutine(RestartStage());
    }

    IEnumerator RestartStage()
    {
        yield return _wait;
        GameManager.Instance.RestartStage();
    }

    private void PlayStepSound()
    {
        _audio.UnPause();
    }

    private void PauseStepSound()
    {
        _audio.Pause();
    }

    private void PlayFaintSound()
    {
        PauseStepSound();
        GameManager.Instance.PlayOneShot(_faintClip);
    }

}
