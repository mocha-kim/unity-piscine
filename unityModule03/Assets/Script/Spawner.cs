using UnityEngine;

namespace Module02
{
    public class Spawner : MonoBehaviour
    {
        private int _enemyIndex = 0;
        private int _objectCount = 0;
        private float _elapsedTime = 0f;

        [SerializeField] private int maxCount = 20;
        [SerializeField] private float duration = 2.0f;
        [SerializeField] private GameObject[] enemyPrefabs;

        private void Start()
        {
            LevelInfo.GetInfo(GameManager.Instance.MapIndex, out _enemyIndex, out maxCount, out duration);
        }

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
                    _objectCount++;
                    Enemy enemy = Instantiate(enemyPrefabs[_enemyIndex], transform.position, Quaternion.identity, transform).GetComponent<Enemy>();
                    enemy.SetSpawner(this, _objectCount);
                }
            }
        }

        public bool IsLastEnemy(int index) => index == maxCount;
    }
}