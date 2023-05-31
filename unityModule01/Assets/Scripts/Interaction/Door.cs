using System.Collections;
using UnityEngine;

namespace Module01.Interaction
{
    public class Door : MonoBehaviour, IInteractionTarget
    {
        private readonly Vector3 _modifyAmount = new Vector3(0f, 0.01f, 0f);
        
        private void OpenDoor()
        {
            StartCoroutine(Disappear());
        }

        public void Modify(Color color) => OpenDoor();

        private IEnumerator Disappear()
        {
            while (transform.localScale.y > 0f)
            {
                transform.localScale -= _modifyAmount;
                yield return null;
            }
            gameObject.SetActive(false);
        }
    }
}