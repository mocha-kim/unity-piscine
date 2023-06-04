using System;
using UnityEngine;

namespace Module04
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        public bool IsGameOver { get; set; }
        public int PlayerInitHP { get; private set; }
        public Vector3 PlayerInitPosition { get; private set; }

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

            PlayerInitHP = 3;
            PlayerInitPosition = new Vector3(-6f, 1f, 0f);
        }
    }
}