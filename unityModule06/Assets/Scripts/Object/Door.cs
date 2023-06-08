using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private readonly float _openSpeed = 100f;
    private WaitForSeconds _wait = new WaitForSeconds(2f);
    
    private GameObject _door;

    private void Awake()
    {
        _door = transform.GetChild(0).gameObject;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(OpenDoor());
        }
    }

    protected IEnumerator OpenDoor()
    {
        var angle = 0f;
        while (angle <= 120f)
        {
            angle += _openSpeed * Time.deltaTime;
            _door.transform.Rotate(Vector3.up, -_openSpeed * Time.deltaTime);
            yield return null;
        }

        angle = 0f;
        yield return _wait;
        
        while (angle <= 120f)
        {
            angle += _openSpeed * Time.deltaTime;
            _door.transform.Rotate(Vector3.up, _openSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
