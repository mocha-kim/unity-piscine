using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Module02
{
	public class Turret : MonoBehaviour
	{
		private float _elapsedTime = 0f;
		[SerializeField] private GameObject _closestTarget;
		private CircleCollider2D _collider;
		private List<GameObject> _targetsInRange = new ();

		[SerializeField] private float range = 4.0f;
		[SerializeField] private float duration = 1f;
		[SerializeField] private float damage = 0.2f;
		[SerializeField] private GameObject bulletPrefab;

		private void Start()
		{
			_collider = GetComponent<CircleCollider2D>();
			_collider.radius = range;
		}

   	 	private void Update()
   	 	{
            if (GameManager.Instance.IsGameOver)
			{
				Destroy(gameObject);
			}

        	_elapsedTime += Time.deltaTime;
        	if (_elapsedTime >= duration)
        	{
            	_elapsedTime = 0f;
				
				DetectTarget();
				if (_closestTarget == null) return;

                Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity, transform).GetComponent<Bullet>();
                bullet.Fire(_closestTarget, damage);
        	}
    	}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.CompareTag("Enemy"))
			{
				_targetsInRange.Add(other.gameObject);
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.CompareTag("Enemy"))
			{
				_targetsInRange.Remove(other.gameObject);
			}
		}

		private void DetectTarget()
		{
			_closestTarget = _targetsInRange.OrderBy(target => {
            	return Vector3.Distance(transform.position, target.transform.position);
        		}).FirstOrDefault();
		}
	}
}