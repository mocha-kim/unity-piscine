using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module04
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageInfo")]
    public class StageInfo : ScriptableObject
    {
        [SerializeField] private int[] _totalCounts;
        private List<Dictionary<int, bool>> _isCollectedleaves = new();

        public int StageCount => _totalCounts.Length;

        private void OnValidate()
        {
            for (int i = 0; i < StageCount; i++)
            {
                _isCollectedleaves.Add(new Dictionary<int, bool>());
                for (int j = 0; j < _totalCounts[i]; j++)
                {
                    _isCollectedleaves[i][j] = false;
                }
            }
        }

        public bool IsCollectedLeaf(int stageIndex, int leafIndex) => _isCollectedleaves[stageIndex][leafIndex];
        public void CollectLeaf(int stageIndex, int leafIndex) => _isCollectedleaves[stageIndex][leafIndex] = true;
    }
}