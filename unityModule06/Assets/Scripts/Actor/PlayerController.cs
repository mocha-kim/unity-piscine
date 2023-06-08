using UnityEngine;


namespace Actor
{
    public class PlayerController : MonoBehaviour
    {
        private bool _isFPSMode = false;

        private readonly float _rotateSpeed = 4f;
        private readonly float _speed = 5f;
        private Vector3 _dirVector = Vector3.zero;

        private GameObject _body;
        private CharacterController _controller;

        private int _speedIndex;
        private Animator _animator;
        [SerializeField] private GameObject _TPSCamera;

        private void Awake()
        {
            _body = transform.GetChild(0).gameObject;
            _controller = GetComponent<CharacterController>();

            _speedIndex = Animator.StringToHash("speed");
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                _TPSCamera.SetActive(_isFPSMode);
                _body.SetActive(_isFPSMode);
                _isFPSMode = !_isFPSMode;
            }
            
            _dirVector.x = Input.GetAxis("Horizontal");
            _dirVector.z = Input.GetAxis("Vertical");
            if (_isFPSMode)
            {
                float yRotateSize = Input.GetAxis("Mouse X") * _rotateSpeed;
                float yRotate = transform.eulerAngles.y + yRotateSize;

                transform.eulerAngles = new Vector3(0f, yRotate, 0f);

                _dirVector = transform.forward * _dirVector.z + transform.right * _dirVector.x;
            }
            else
            {
                if (_dirVector != Vector3.zero)
                    transform.forward = _dirVector;
            }
            _controller.Move(_dirVector * _speed * Time.deltaTime);
            _animator.SetFloat(_speedIndex, _dirVector.magnitude);
        }
    }
}