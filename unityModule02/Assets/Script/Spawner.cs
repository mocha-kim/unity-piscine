using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
    public class Spawner : MonoBehaviour
    {
        private int _objectCount = 0;
        private int _maxCount = 10;
        private float _elapsedTime = 0f;

        [SerializeField] private float duration = 2.0f;
        [SerializeField] private GameObject enemyPrefab;

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= duration)
            {
                if (GameManager.Instance.IsGameOver)
                {
                    gameObject.SetActive(false);
                    return;
                }
                _elapsedTime = 0f;
                if (_objectCount < _maxCount)
                {
                    Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform).GetComponent<Enemy>();
                    enemy.SetSpawner(gameObject);
                    _objectCount++;
                }
            }
        }
    }
}