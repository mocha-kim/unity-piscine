using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    private Image _defeat;
    private Image _win;
    private Color _color = Color.white;

    private float _changeValue = 0f;
    private readonly float _fadeTime = 3f;

    private void Awake()
    {
        _defeat = transform.GetChild(0).GetComponent<Image>();
        _win = transform.GetChild(1).GetComponent<Image>();
    }

    private void Start()
    {
        GameManager.Instance.OnClearGame += OnClearGame;
        GameManager.Instance.OnCaughtTarget += OnCaughtTarget;
        if (GameManager.Instance.IsRestarted)
        {
            _color.a = 1f;
            _defeat.color = _color;
            StartCoroutine(FadeOut(_defeat));
        }
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnClearGame -= OnClearGame;
        GameManager.Instance.OnCaughtTarget -= OnCaughtTarget;
    }

    private void OnClearGame()
    {
        _color.a = 0f;
        _defeat.color = _color;
        StartCoroutine(FadeIn(_defeat));
    }

    private void OnCaughtTarget()
    {
        _color.a = 0f;
        _defeat.color = _color;
        StartCoroutine(FadeIn(_defeat));
    }

    private IEnumerator FadeIn(Image image)
    {
        _changeValue = 0f;
        while (_color.a < 1f)
        {
            _changeValue = Time.deltaTime / _fadeTime;
            _color.a += _changeValue;
            image.color = _color;
            yield return null;
        }
    }

    private IEnumerator FadeOut(Image image)
    {
        _changeValue = 0f;
        while (_color.a > 0f)
        {
            _changeValue = Time.deltaTime / _fadeTime;
            _color.a -= _changeValue;
            image.color = _color;
            yield return null;
        }
    }
}
