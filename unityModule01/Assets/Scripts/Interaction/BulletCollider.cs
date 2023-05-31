using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module01.Interaction
{
    public class BulletCollider : MonoBehaviour
    {
        private GameObject _parent;

        private void Awake()
        {
            _parent = gameObject.transform.parent.gameObject;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.GameOver();
                _parent.transform.parent.gameObject.SetActive(false);
            }
            else if (other.gameObject.CompareTag("Obstacle"))
            {
                _parent.SetActive(false);
            }
        }
    }
}
