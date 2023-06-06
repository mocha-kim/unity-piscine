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

		private int _stageIndex = 0;
		private int _leavesCount = 0;
		[SerializeField] private StageInfo _stageInfo;

		private int _totalPoints = 0;

		public Action OnStageClear;
		public Action OnPointNotEnough;

        public bool IsGameOver { get; set; }
        public int PlayerHP => _hp;
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

            _hp = _initHP;
            PlayerInitPosition = new Vector3(-6f, 1f, 0f);
        }

		public bool IsCollectedLeaf(int index) => _stageInfo.IsCollectedLeaf(_stageIndex, index);

		public void CollectLeaf(int index)
		{
			_stageInfo.CollecteLeaf(_stageIndex, index);
			_leavesCount++;
			_totalPoints += 5;
		}

		public bool ClearStage()
		{
			if (_leavesCount == 5)
			{
				LoadStage(_stageIndex);
				return true;
			}
			OnPointNotEnough?.Invoke();
			return false;
		}

		public void LoadStage(int index)
		{

			SceneManager.LoadScene("Stage" + (index + 1));
		}    
	}
}