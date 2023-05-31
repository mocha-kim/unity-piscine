using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Module01.Interaction
{
    public class Turret : MonoBehaviour
    {
        private float _elapsedTime = 0f;
        private IObjectPool<Bullet> _objectPool;

        private int _maxCount;
        private int _bulletCount = 0;
        private List<Bullet> _bullets = new ();
        private Vector3 _offset = new Vector3(0f, 0.75f, 0f);

        [SerializeField] private Color color = Color.Blue;
        [SerializeField] private float shootDuration = 1.0f;
        [SerializeField] private float bulletSpeed = 1.0f;

        private void Start()
        {
            _maxCount = transform.childCount - 2;
            for (int i = 0; i < _maxCount; i++)
            {
                var bullet = transform.GetChild(i + 2).gameObject.GetComponent<Bullet>();
                bullet.SetColor(color);
                _bullets.Add(bullet);
                bullet.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime < shootDuration)
                return;

            ActivateBullet();
            _elapsedTime = 0f;
        }

        private void ActivateBullet()
        {
            _bullets[_bulletCount].gameObject.SetActive(true);
            _bullets[_bulletCount].gameObject.transform.position = transform.position + _offset;
            _bullets[_bulletCount].Rigidbody.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
            _bulletCount++;
            _bulletCount %= _maxCount;
        }
    }
}
