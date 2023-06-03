using System;
using UnityEngine;

namespace Module02
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        private float _elapsedTime = 0f;
        private float _energyDuration = 1.5f;
        [SerializeField] private int _energy;
        public int Energy
        {
            get => _energy;
            set
            {
                _energy = value;
                
            }
        }
        
        public Action<int> OnEnergyChanged;
        public bool IsGameOver { get; private set; }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            Init();
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _energyDuration)
            {
                _energy++;
                _elapsedTime = 0f;
                OnEnergyChanged?.Invoke(_energy);
            }
        }

        private void Init()
        {
            IsGameOver = false;
            Energy = 5;
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            IsGameOver = true;
        }
    }
}