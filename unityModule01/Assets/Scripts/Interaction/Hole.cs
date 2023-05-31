using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private bool _isGameOver = false;
    private BoxCollider _collider;
    private Collider _floorCollider;

    private Vector3 _min;
    private Vector3 _max;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _floorCollider = GameObject.Find("Floor").GetComponent<Collider>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        
        _min = other.bounds.min;
        _max = new Vector3(other.bounds.max.x, _min.y ,other.bounds.max.z);
        if (_collider.bounds.Contains(_min) && _collider.bounds.Contains(_max))
        {
            Physics.IgnoreCollision(other, _floorCollider);
            GameManager.Instance.StopCamera();
            _isGameOver = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _isGameOver)
        {
            GameManager.Instance.GameOver();
        }
    }
}
