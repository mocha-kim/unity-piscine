using UnityEngine;

namespace Module01.Interaction
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private Color _color;
        public Color Color => _color;
    }
}