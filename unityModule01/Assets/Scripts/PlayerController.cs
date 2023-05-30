using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private KeyCode selectKey;
    [SerializeField] private Vector3 offset;
    
    private bool _isActivate = false;
    private float _horizontal;
    private Vector3 _dirVector;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        gameObject.transform.position = offset;
    }

    void Update()
    {
        if (Input.GetAxis("Reset") > 0f)
        {
            gameObject.transform.position = offset;
        }
        
        if (Input.GetKeyDown(selectKey))
        {
            CameraMove.Instance.SetTarget(gameObject);
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }

        if (_isActivate)
        {
            _horizontal = Input.GetAxis("Horizontal");
            _dirVector = new(_horizontal, 0f, 0f);
            _dirVector *= speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _dirVector);
    }

    public void SetActive(bool isActive)
    {
        _isActivate = isActive;
        if (!isActive)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }
}
