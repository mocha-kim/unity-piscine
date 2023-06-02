using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
    public class Base : MonoBehaviour, IDamagable
    {
        private float _hp = 5.0f;
        public float HP => _hp;

        public void Damaged(float damage)
        {
            _hp -= damage;
            Debug.Log("HP: " + _hp);
            if (_hp <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}