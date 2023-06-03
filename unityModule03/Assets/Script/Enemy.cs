using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
    public class Enemy : MonoBehaviour, IDamagable
    {
        private int _index; 
        private float _hp = 3.0f;
        private Spawner _spawner;
        
        [SerializeField] private float damage = 1.0f;
		[SerializeField] private float speed = 2f;
        [SerializeField] private Vector3 _moveVector = Vector3.down;

		private void Start()
		{
			_moveVector *= speed;
		}

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

        public void SetSpawner(Spawner spawner, int index)
        {
            _spawner = spawner;
            _index = index;
        }

        public void Damaged(float damage)
        {
            _hp -= damage;
            if (_hp <= 0)
            {
                Destroy(gameObject);
                GameManager.Instance.Energy++;
                GameManager.Instance.KillCount++;
                if (_spawner.IsLastEnemy(_index))
                {
                    GameManager.Instance.GameClear();
                }
            }
        }
    }
}