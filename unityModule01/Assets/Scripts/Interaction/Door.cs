using System;
using System.Collections;
using UnityEngine;

namespace Module01.Interaction
{
    public class Door : MonoBehaviour, IInteractionTarget
    {
        private bool _isOpened = false;
        private readonly Vector3 _modifyAmount = new Vector3(0f, 0.01f, 0f);

        private void Update()
        {
            if (!_isOpened)
                return;
            
            transform.localScale -= _modifyAmount;
            if (transform.localScale.y <= 0f)
            {
                gameObject.SetActive(false);
            }
        }

        private void OpenDoor()
        {
            _isOpened = true;
        }

        public void Modify(Color color) => OpenDoor();
    }
}