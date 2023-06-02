using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
    public class Spawner : MonoBehaviour
    {
        private int _objectCount = 0;
        private float _elapsedTime = 0f;

        [SerializeField] private int maxCount = 20;
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
                if (_objectCount < maxCount)
                {
                    Enemy enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity, transform).GetComponent<Enemy>();
                    enemy.SetSpawner(gameObject);
                    _objectCount++;
                }
            }
        }
    }
}