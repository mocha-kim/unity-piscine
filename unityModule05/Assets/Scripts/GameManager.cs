using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Module04
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

		private int _hp = 3;
		private readonly int _initHP = 3;
		private int _deathCount = 0;

		private int _stageIndex = 0;
		private int _unlockIndex = 0;
		private int _leavesCount = 0;
		private int _currentPoints = 0;
		private int _totalPoints = 0;
		[SerializeField] private StageInfo _stageInfo;


		public Action<int> OnHPChanged;
		public Action<int> OnLeafCollected;
		public Action OnPointNotEnough;

        public bool IsGameOver { get; set; }
        public Vector3 PlayerInitPosition { get; private set; }
        public int PlayerHP
		{
			get => _hp;
			set
			{
				_hp = value;
				PlayerPrefs.SetInt("HP", _hp);
				OnHPChanged?.Invoke(_hp);
			}
		}

        public int CurrentPoint => _currentPoints;

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

            PlayerInitPosition = new Vector3(-6f, 1f, 0f);
        }

		public bool IsCollectedLeaf(int index) => _stageInfo.IsCollectedLeaf(_stageIndex, index);

		public void CollectLeaf(int index)
		{
			_stageInfo.CollectLeaf(_stageIndex, index);
			_leavesCount++;
			_totalPoints += 5;
			_currentPoints += 5;
			PlayerPrefs.SetInt("Points", _totalPoints);
			OnLeafCollected?.Invoke(_currentPoints);
		}

		public void Respawn()
		{
			_deathCount++;
			PlayerPrefs.SetInt("Death", _unlockIndex);
            PlayerHP = _initHP;
		}

		public bool ClearStage()
		{
			if (_leavesCount >= 5)
			{
				_stageIndex = (_stageIndex + 1) % _stageInfo.StageCount;
				_unlockIndex = Math.Max(_unlockIndex, _stageIndex);
				PlayerPrefs.SetInt("Unlock", _unlockIndex);
				LoadStage(_stageIndex);
				return true;
			}
			OnPointNotEnough?.Invoke();
			return false;
		}

		public void LoadStage(int index)
		{
			PlayerPrefs.SetInt("Played", index);
			_leavesCount = _stageInfo.GetCollectedCount(index);
			_currentPoints = 0;
			PlayerHP = _initHP;
			SceneManager.LoadScene("Stage" + (index + 1));
		}

		public void NewGame()
		{
			PlayerPrefs.SetInt("HP", _initHP);
			PlayerPrefs.SetInt("Death", 0);
			PlayerPrefs.SetInt("Points", 0);
			PlayerPrefs.SetInt("Played", 0);
			PlayerPrefs.SetInt("Unlock", 0);
			LoadGame();
			_stageInfo.InitInfo();
		}

		public void LoadGame()
		{
			_hp = PlayerPrefs.GetInt("HP", _initHP);
			_deathCount = PlayerPrefs.GetInt("Death", 0);
			_totalPoints = PlayerPrefs.GetInt("Points", 0);
			_stageIndex = PlayerPrefs.GetInt("Played", 0);
			_unlockIndex = PlayerPrefs.GetInt("Unlock", 0);
		}
	}
}