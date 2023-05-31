using UnityEngine;

namespace Module01.Interaction
{
    public class Exit : MonoBehaviour
    {
        private string _name;
        [SerializeField] private GameObject target;

        private MeshRenderer _mesh;
        private UnityEngine.Color _untouched;
        private UnityEngine.Color _touched;

        private void Awake()
        {
            _name = target.name;

            _mesh = GetComponent<MeshRenderer>();
            _untouched = _mesh.material.color;
            _touched = target.GetComponent<MeshRenderer>().material.color;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject == target)
            {
                _mesh.material.color = _touched;
                GameManager.Instance.AlignPlayerExit(_name);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject == target)
            {
                _mesh.material.color = _untouched;
                GameManager.Instance.BreakPlayerExit(_name);
            }
        }
    }
}