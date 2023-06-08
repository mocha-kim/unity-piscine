using UnityEngine;

namespace Object
{
    public class SpecialDoor : Door
    {
        protected override void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && GameManager.Instance.IsCollectedAllKeys())
            {
                StartCoroutine(OpenDoor());
            }
        }
    }
}