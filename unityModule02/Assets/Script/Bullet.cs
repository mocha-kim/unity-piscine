using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
	public class Bullet : MonoBehaviour
	{
	    private float _speed = 5.0f;
		private float _damage = 1.0f;
		private float _angle;
	    private Vector3 _direction;
	    private Rigidbody2D _rigidbody;
	    
	    private void OnEnable()
	    {
	        _rigidbody = GetComponent<Rigidbody2D>();
	    }

	    public void Fire(GameObject target, float basicDamage)
	    {
			_damage += basicDamage;
	        _direction = target.transform.position - transform.position;
	        _direction.Normalize();
			_angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
            _rigidbody.AddForce(_direction * _speed, ForceMode2D.Impulse);
	    }

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (other.gameObject.CompareTag("Enemy"))
			{
                other.gameObject.GetComponent<IDamagable>().Damaged(_damage);
                Destroy(gameObject);
			}
		}
	}
}