using System;
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

		private int _leavesCount = 0;
		private bool[] _isCollectedleaves = new bool[5];

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

		public bool IsCollectedLeaf(int index) => _isCollectedleaves[index];

		public void InitLeaves()
		{
			for (int i = 0; i < 5; i++)
			{
				_isCollectedleaves[i] = false;
			}
		}

		public void CollectLeaf(int index)
		{
			_isCollectedleaves[index] = true;
			_leavesCount++;
			_totalPoints += 5;
		}

		public bool ClearStage()
		{
			if (_leavesCount == 5)
			{
				OnStageClear?.Invoke();
				Debug.Log("clear");
				return true;
			}
			OnPointNotEnough?.Invoke();
			Debug.Log("need more leaf");
			return false;
		}

		public void LoadStage(int index)
		{
			SceneManager.LoadScene("Stage" + index);
		}    
	}
}