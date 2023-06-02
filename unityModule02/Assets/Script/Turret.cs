using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
	public class Turret : MonoBehaviour
	{
		private float _elapsedTime = 0f;
		private GameObject _target;

		[SerializeField] private float duration = 0.25f;
		[SerializeField] private float damage = 0.2f;
		[SerializeField] private GameObject bulletPrefab;

   	 	private void Update()
   	 	{
			DetectTarget();
        	_elapsedTime += Time.deltaTime;
        	if (_elapsedTime >= duration)
        	{
            	if (GameManager.Instance.IsGameOver)
            	{
                	gameObject.getComponent<Turret>().SetActive(false);
                	return;
            	}
            	_elapsedTime = 0f;
                Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform).GetComponent<Bullet>();
                bullet.Fire(gameObject);
        	}
    	}

		private void DetectTarget()
		{
		}
	}
}