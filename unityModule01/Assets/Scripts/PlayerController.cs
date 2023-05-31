using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private KeyCode selectKey;
    [SerializeField] private float speed = 20.0f;
    
    private Vector3 offset;
    
    private bool _isActivate = false;
    private bool _isGrounded = true;
    
    private float _jumpPower = 5.0f;
    private float _horizontal;
    private Vector3 _dirVector;
    private Rigidbody _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        offset = gameObject.transform.position;
    }

    void Update()
    {
        if (Input.GetAxis("Reset") > 0f)
        {
            gameObject.transform.position = offset;
        }
        
        if (Input.GetKeyDown(selectKey))
        {
            CameraMove.Instance.SetTarget(gameObject);
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (_isActivate)
        {
            _horizontal = Input.GetAxis("Horizontal");
            _dirVector = new(_horizontal, 0f, 0f);
            _dirVector *= speed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);
                _isGrounded = false;
            }
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _dirVector);
    }

    public void SetActive(bool isActive)
    {
        _isActivate = isActive;
        if (!isActive)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            _isGrounded = true;
        }
    }
}
