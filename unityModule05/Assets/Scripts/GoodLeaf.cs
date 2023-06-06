using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module04
{
    public class GoodLeaf : MonoBehaviour
    {
        [SerializeField] private int index;

        private void Start()
        {
            if (GameManager.Instance.IsCollectedLeaf(index))
            {
                gameObject.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.Instance.CollectLeaf(index);
                gameObject.SetActive(false);
            }
        }
    }
}
