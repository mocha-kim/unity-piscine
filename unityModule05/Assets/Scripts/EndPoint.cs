using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module04
{
	public class EndPoint : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				GameManager.Instance.ClearStage();
			}
		}
	}
}