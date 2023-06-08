using UnityEngine;


namespace Actor
{
    public class PlayerController : MonoBehaviour
    {
        private readonly float _speed = 5f;
        private Vector3 _dirVector = Vector3.zero;
        
        private CharacterController _controller;

        private int _speedIndex;
        private Animator _animator;

        private void Awake()
        {
            _controller = GetComponent<CharacterController>();

            _speedIndex = Animator.StringToHash("speed");
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _dirVector.x = Input.GetAxis("Horizontal");
            _dirVector.z = Input.GetAxis("Vertical");
            if (_dirVector != Vector3.zero)
                transform.forward = _dirVector;

            _controller.Move(_dirVector * _speed * Time.deltaTime);
            _animator.SetFloat(_speedIndex, _dirVector.magnitude);
        }
    }
}