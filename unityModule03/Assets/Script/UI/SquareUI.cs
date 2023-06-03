using System;
using UnityEngine;

namespace Module02.UI
{
    public class SquareUI : MonoBehaviour
    {
        private bool _isOccupied = false;
        private Vector3 _offset = new Vector3(0.45f, -0.25f, 0f);

        [SerializeField] private bool isRightSide = false;
        public bool IsRightSide => isRightSide;

        private void Awake()
        {
            if (isRightSide)
            {
                _offset.x = -_offset.x;
            }
        }

        public Vector3 GetPositionInWorld()
        {
            return transform.position + _offset;
        }

        public bool OccupySquare(int cost)
        {
            if (_isOccupied || GameManager.Instance.Energy < cost)
            {
                return false;
            }

            GameManager.Instance.Energy -= cost;
            _isOccupied = true;
            return true;
        }
    }
}