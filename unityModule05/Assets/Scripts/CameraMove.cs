using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private GameObject target;
    private Vector3 _position;
    
    [SerializeField] private Vector3 minPos;
    [SerializeField] private Vector3 maxPos;
    private Vector3 _offset = new Vector3(0f, 0f, -10f);
    private float _speed = 5.0f;

    private void LateUpdate()
    {
        _position = Vector3.Lerp(_position, target.transform.position + _offset, Time.deltaTime * _speed);
        _position.x = Mathf.Clamp(_position.x, minPos.x, maxPos.x);
        _position.y = Mathf.Clamp(_position.y, minPos.y, maxPos.y);
        _position.z = Mathf.Clamp(_position.z, minPos.z, maxPos.z);

        transform.position = _position;
    }
}
