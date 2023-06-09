using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool _isOpened = false;
    private readonly float _openSpeed = 100f;
    private WaitForSeconds _wait = new WaitForSeconds(2f);
    
    private GameObject _door;

    private AudioSource _audio;
    [SerializeField] private AudioClip _openClip;
    [SerializeField] private AudioClip _closeClip;

    private void Awake()
    {
        _door = transform.GetChild(0).gameObject;
        _audio = GetComponent<AudioSource>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor());
        }
    }
    
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CloseDoor());
        }
    }

    protected IEnumerator OpenDoor()
    {
        if (_isOpened) yield break;
        _isOpened = true;
        
        _audio.PlayOneShot(_openClip);
        var angle = 0f;
        while (angle <= 120f)
        {
            angle += _openSpeed * Time.deltaTime;
            _door.transform.Rotate(Vector3.up, -_openSpeed * Time.deltaTime);
            yield return null;
        }
    }
    
    protected IEnumerator CloseDoor()
    {
        yield return _wait;
        
        _audio.PlayOneShot(_closeClip);
        var angle = 0f;
        while (angle <= 120f)
        {
            angle += _openSpeed * Time.deltaTime;
            _door.transform.Rotate(Vector3.up, _openSpeed * Time.deltaTime);
            yield return null;
        }

        _isOpened = false;
    }
}
