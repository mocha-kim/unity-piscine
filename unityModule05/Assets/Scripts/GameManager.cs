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
		private int _leavesCount = 0;
		[SerializeField] private StageInfo _stageInfo;

		private int _unlockIndex = 0;
		private int _totalPoints = 0;

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
				OnHPChanged?.Invoke(_hp);
			}
		}
        public int TotalPoints => _totalPoints;

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

            PlayerHP = _initHP;
            PlayerInitPosition = new Vector3(-6f, 1f, 0f);
        }

		public bool IsCollectedLeaf(int index) => _stageInfo.IsCollectedLeaf(_stageIndex, index);

		public void CollectLeaf(int index)
		{
			_stageInfo.CollectLeaf(_stageIndex, index);
			_leavesCount++;
			_totalPoints += 5;
			OnLeafCollected?.Invoke(_totalPoints);
		}

		public void Respawn()
		{
			_deathCount++;
            PlayerHP = _initHP;
		}

		public bool ClearStage()
		{
			if (_leavesCount >= 5)
			{
				_stageIndex = (_stageIndex + 1) % _stageInfo.StageCount;
				_unlockIndex = _stageIndex;
				LoadStage(_stageIndex);
				return true;
			}
			OnPointNotEnough?.Invoke();
			return false;
		}

		public void LoadStage(int index)
		{
			_leavesCount = _stageInfo.GetCollectedCount(index); 
			Debug.Log("Stage1: " + (index + 1) + ", " + _leavesCount);
			SceneManager.LoadScene("Stage" + (index + 1));
		}    
	}
}