using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
    public class Base : MonoBehaviour, IDamagable
    {
        private float _elapsedTime = 0f;
        private readonly float _energyDuration = 1.5f;
        
        private float _baseHp = 5;

        private void Start()
        {
            GameManager.Instance.InitBase(_baseHp);
        }
        
        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _energyDuration)
            {
                GameManager.Instance.Energy++;
                _elapsedTime = 0f;
            }
        }

        public void Damaged(float damage)
        {
            GameManager.Instance.HP -= damage;
            Debug.Log("HP: " + GameManager.Instance.HP);
            if (GameManager.Instance.HP <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}