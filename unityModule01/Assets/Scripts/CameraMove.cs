using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private static CameraMove _instance;
    public static CameraMove Instance => _instance;

    private bool _isMoving = false;
    private float _speed = 3.0f;
    private Vector3 _init = new Vector3(0f, 5, -10f);
    private Vector3 _offset = new Vector3(0f, 1.5f, -3f);
    private GameObject _target;
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _target = null;
    }

    public void StopMove() => _isMoving = false;

    public void SetTarget(GameObject target)
    {
        _target?.GetComponent<PlayerController>().SetActive(false);
        _target = target;
        _target.GetComponent<PlayerController>().SetActive(true);
        _isMoving = true;
    }

    private void Update()
    {
        if (Input.GetAxis("Reset") > 0f)
        {
            _target = null;
            _isMoving = false;
            transform.position = _init;
        }

        if (GameManager.Instance.IsGameOver)
        {
            StopMove();
        }
    }
    
    private void LateUpdate()
    {
        if (!_isMoving) return;
        transform.position = Vector3.Lerp(transform.position, _offset + _target.transform.position, Time.deltaTime + _speed);
    }
}
