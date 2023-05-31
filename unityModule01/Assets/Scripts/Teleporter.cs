using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    private readonly float _duration = 2.0f;
    private bool _isActivated = true;
    private ParticleSystem _particle;

    [SerializeField] private Teleporter linked;
    private Vector3 _destination;

    private void Start()
    {
        _particle = transform.GetChild(0).GetComponent<ParticleSystem>();
        _destination = linked.gameObject.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isActivated) return;
        
        Vector3 tmp = other.transform.position;
        tmp.x = _destination.x;
        tmp.y += _destination.y - transform.position.y;
        other.transform.position = tmp;

        StartCoolTime();
        linked.StartCoolTime();
    }

    public void StartCoolTime()
    {
        StartCoroutine(CoolTime());
    }
    
    private IEnumerator CoolTime()
    {
        _isActivated = false;
        _particle.Stop();
        float elapsedTime = _duration;
        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime;
            yield return null;
        }
        _isActivated = true;
        _particle.Play();
    }
}
