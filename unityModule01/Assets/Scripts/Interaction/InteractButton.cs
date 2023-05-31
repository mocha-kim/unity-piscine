using System.Collections.Generic;
using UnityEngine;

namespace Module01.Interaction
{
    public class InteractButton : MonoBehaviour
    {
        private bool _isActivated = true;
        [SerializeField] private bool isDisposable = true;
        [SerializeField] private List<GameObject> targets;

        private void OnTriggerEnter(Collider other)
        {
            if (!_isActivated) return;
        
            if (isDisposable)
            {
                _isActivated = false;
            }
        
            foreach (var target in targets)
            {
                target.GetComponent<IInteractionTarget>().Modify(other.GetComponent<Character>().Color);
            }
        }
    }
}
