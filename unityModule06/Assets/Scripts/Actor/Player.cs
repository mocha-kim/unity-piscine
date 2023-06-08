using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _caughtIndex;
    private Animator _animator;

    private WaitForSeconds _wait = new WaitForSeconds(3f);

    private void Awake()
    {
        _caughtIndex = Animator.StringToHash("caught");
        _animator = GetComponent<Animator>();
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
        StartCoroutine(RestartStage());
    }

    IEnumerator RestartStage()
    {
        yield return _wait;
        GameManager.Instance.RestartStage();
    }
}
