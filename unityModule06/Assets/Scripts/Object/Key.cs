using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private GameObject _key;
    private readonly Vector3 _moveVector = new Vector3(0f, 2f, 0f);

    private void Awake()
    {
        _key = transform.GetChild(0).gameObject;
    }

    private void Start()
    {
        StartCoroutine(MoveUpAndDown());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.CollectKey();
            gameObject.SetActive(false);
        }
    }

    private IEnumerator MoveUpAndDown()
    {
        while (true)
        {
            while (_key.transform.position.y < 1.25f)
            {
                _key.transform.position += _moveVector * Time.deltaTime;
                yield return null;
            }
            while (_key.transform.position.y > 0.25f)
            {
                _key.transform.position -= _moveVector * Time.deltaTime;
                yield return null;
            }
        }
    }
}
