using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Module02
{
	public class Bullet : MonoBehaviour
	{
	    private float _speed = 2.5f;
	    private Vector3 _direction;
	    private Rigidbody2D _rigidbody;
	    
	    private void OnEnable()
	    {
	        _rigidbody = GetComponent<Rigidbody2D>();
	    }

	    public void Fire(GameObject target)
	    {
	        _direction = target.transform.position - transform.position;
	        _direction.Normalize();
	    }
	}
}