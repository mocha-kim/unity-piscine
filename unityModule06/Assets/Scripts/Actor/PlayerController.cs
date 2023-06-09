using UnityEngine;

namespace Actor
{
    public class PlayerController : MonoBehaviour
    {
        private bool _isTPSMode = false;
        private bool _isClear = false;

        private readonly float _rotateSpeed = 8f;
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
        
        private void Start()
        {
            GameManager.Instance.OnClearGame += OnClearGame;
        }

        private void Update()
        {
            if (GameManager.Instance.IsPlayerDead || _isClear) return;
            
            if (Input.GetKeyDown(KeyCode.C))
            {
                Cursor.visible = _isTPSMode;
                _TPSCamera.SetActive(_isTPSMode);
                _body.SetActive(_isTPSMode);
                _isTPSMode = !_isTPSMode;
            }
            
            if (_isTPSMode)
            {
                float yRotateSize = Input.GetAxis("Mouse X") * _rotateSpeed;
                float yRotate = transform.eulerAngles.y + yRotateSize;

                transform.eulerAngles = new Vector3(0f, yRotate, 0f);

                if (Input.GetKey(KeyCode.Z))
                {
                    _dirVector = transform.forward;
                }
                else
                {
                    _dirVector = Vector3.zero;
                }
            }
            else
            {
                _dirVector.x = Input.GetAxis("Horizontal");
                _dirVector.z = Input.GetAxis("Vertical");
                if (_dirVector != Vector3.zero)
                    transform.forward = _dirVector;
            }
            _controller.Move(_dirVector * _speed * Time.deltaTime);
            _animator.SetFloat(_speedIndex, _dirVector.magnitude);
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnClearGame -= OnClearGame;
        }

        private void OnClearGame() => _isClear = true;
    }
}