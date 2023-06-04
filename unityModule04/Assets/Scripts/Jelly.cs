using System;
using Module04;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    private float _epasedTIme = 0f;
    private float _destroyTime = 3.0f;
    private float _speed = 2.0f;
    private int _damage = 1;

    private int _hitTriggrtId;
    private Animator _animator;

    private void Awake()
    {
        _hitTriggrtId = Animator.StringToHash("hitTrigger");
        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (GameManager.Instance.IsGameOver)
            return;
        _epasedTIme += Time.deltaTime;
        if (_epasedTIme >= _destroyTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void Throw(bool isToRightSide)
    {
        GetComponent<SpriteRenderer>().flipX = !isToRightSide;
        GetComponent<Rigidbody2D>().AddForce((isToRightSide ? Vector2.right : Vector2.left)
                                             * _speed, ForceMode2D.Impulse);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().OnDamaged(_damage);
            _animator.SetTrigger(_hitTriggrtId);
        }
    }

    public void OnAnimationEnd()
    {
        Destroy(gameObject);
    }
}
