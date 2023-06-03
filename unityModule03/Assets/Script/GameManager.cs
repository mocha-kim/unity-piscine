using System;
using UnityEngine;

namespace Module02
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        private float _baseHp;
        private float _hp;
        public Action<float> OnHPChanged;
        
        private int _energy;
        public Action<int> OnEnergyChanged;

        public float PercentHP => _hp / _baseHp;
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

        private void Init()
        {
            IsGameOver = false;
            Energy = 5;
            HP = 5;
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            IsGameOver = true;
        }

        public void InitBase(float baseHp)
        {
            _baseHp = baseHp;
        }
    }
}