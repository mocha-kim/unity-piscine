using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Module04
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StageInfo")]
    public class StageInfo : ScriptableObject
    {
        [Serializable]
        public struct _Stage
        {
            public int leafCount;
            public bool[] isCollected;
        }
        [SerializeField] private _Stage[] _isCollectedleaves;

        public int StageCount => _isCollectedleaves.Length;

        public void InitInfo()
        {
            foreach (var stage in _isCollectedleaves)
            {
                for (int i = 0; i < stage.isCollected.Length; i++)
                {
                    stage.isCollected[i] = false;
                }
            }
        }

        public bool IsCollectedLeaf(int stageIndex, int leafIndex) => _isCollectedleaves[stageIndex].isCollected[leafIndex];
        public void CollectLeaf(int stageIndex, int leafIndex) => _isCollectedleaves[stageIndex].isCollected[leafIndex] = true;
        public int GetCollectedCount(int stageIndex) => _isCollectedleaves[stageIndex].isCollected.Count(leaf => leaf);
    }
}