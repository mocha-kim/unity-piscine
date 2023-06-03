using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Module02
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        [SerializeField] private float baseHp = 5.0f;
        private float _hp;
        public Action<float> OnHPChanged;

        [SerializeField] private int baseEnergy = 8;
        private int _energy;
        public Action<int> OnEnergyChanged;

        public float PercentHP => _hp / baseHp;
        public float HP
        {
            get => _hp;
            set
            {
                _hp = value;
                OnHPChanged?.Invoke(_hp);
            }
        }
        public int Energy
        {
            get => _energy;
            set
            {
                _energy = value;
                OnEnergyChanged?.Invoke(_energy);
            }
        }
        public bool IsGameOver { get; private set; }
        public bool IsMapClear { get; private set; } 
        public int KillCount { get; set; }
        public int MapIndex { get; private set; }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                MapIndex = 1;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Init();
        }

        public void Init()
        {
            IsGameOver = false;
            Energy = baseEnergy;
            HP = baseHp;

            IsMapClear = false;
            KillCount = 0;
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            IsMapClear = false;
            IsGameOver = true;
            SceneManager.LoadScene("Score");
        }

        public void GameClear()
        {
            Debug.Log(SceneManager.GetActiveScene().name + " Clear!");
            IsMapClear = true;
            MapIndex = (MapIndex == 3) ? 0 : MapIndex + 1;
            SceneManager.LoadScene("Score");
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void ResumeGame()
        {
            Time.timeScale = 1.0f;
        }
    }
}