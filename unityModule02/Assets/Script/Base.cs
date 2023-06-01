using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
    public class Base : MonoBehaviour, IDamagable
    {
        private int _hp = 5;
        public int HP => _hp;

        public void Damaged(int damage)
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