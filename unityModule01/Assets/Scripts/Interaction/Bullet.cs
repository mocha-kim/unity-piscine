using System;
using UnityEngine;
using Color = Module01.Interaction.Color;

namespace Module01.Interaction
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameObject _blue;
        [SerializeField] private GameObject _yellow;
        [SerializeField] private GameObject _red;
        private Rigidbody _rigidbody;

        public Rigidbody Rigidbody => _rigidbody;

        public void SetColor(Color color)
        {
            switch (color)
            {
                case Color.Blue:
                    _blue.SetActive(true);
                    _rigidbody = _blue.GetComponent<Rigidbody>();
                    break;
                case Color.Yellow:
                    _yellow.SetActive(true);
                    _rigidbody = _yellow.GetComponent<Rigidbody>();
                    break;
                case Color.Red:
                    _red.SetActive(true);
                    _rigidbody = _red.GetComponent<Rigidbody>();
                    break;
                case Color.Default:
                default:
                    break;
            }
        }

        private void Awake()
        {
            _blue = transform.GetChild(0).gameObject;
            _yellow = transform.GetChild(1).gameObject;
            _red = transform.GetChild(2).gameObject;
        }
    }
}