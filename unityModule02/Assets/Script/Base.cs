using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
    public class Base : MonoBehaviour, IDamagable
    {
        private int _hp = 5;
        public int HP => _hp;
        
        void Update()
        {

        }

        public void Damaged(int damage)
        {
            _hp -= damage;
        }
    }
}