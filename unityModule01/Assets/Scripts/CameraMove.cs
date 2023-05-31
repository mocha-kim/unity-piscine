using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private static CameraMove _instance;
    public static CameraMove Instance => _instance;

    private float _speed = 3.0f;
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
        
        _target = GameObject.Find("Thomas");
        _target.GetComponent<PlayerController>().SetActive(true);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _offset + _target.transform.position, Time.deltaTime + _speed);
    }

    public void SetTarget(GameObject target)
    {
        _target.GetComponent<PlayerController>().SetActive(false);
        _target = target;
        _target.GetComponent<PlayerController>().SetActive(true);
    }
}
