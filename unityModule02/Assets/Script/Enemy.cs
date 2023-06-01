using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
    public class Enemy : MonoBehaviour
    {
        private GameObject _spawner;
        
        [SerializeField] private int damage = 1;
        [SerializeField] private Vector3 _moveVector = Vector3.down;

        private void Update()
        {
            if (GameManager.Instance.IsGameOver)
            {
                Destroy(gameObject);
                return;
            }
            transform.position += _moveVector * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.GetComponent<IDamagable>().Damaged(damage);
                Destroy(gameObject);
            }
        }

        public void SetSpawner(GameObject spawner)
        {
            _spawner = spawner;
        }
    }
}