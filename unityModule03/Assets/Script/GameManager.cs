using System;
using UnityEngine;

namespace Module02
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;
        
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
        }

        public void GameOver()
        {
            Debug.Log("Game Over");
            IsGameOver = true;
        }
    }
}