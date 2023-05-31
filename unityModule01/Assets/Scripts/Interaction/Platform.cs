using System;
using UnityEngine;

namespace Module01.Interaction
{
    public class Platform : MonoBehaviour, IInteractionTarget
    {
        [SerializeField] private GameObject current;
        private GameObject _default;
        private GameObject _blue;
        private GameObject _yellow;
        private GameObject _red;

        private void Awake()
        {
            _default = transform.GetChild(0).gameObject;
            _blue = transform.GetChild(1).gameObject;
            _yellow = transform.GetChild(2).gameObject;
            _red = transform.GetChild(3).gameObject;
        }
        
        public void Modify(Color color) => ChangeColor(color);

        private void ChangeColor(Color color)
        {
            switch (color)
            {
                case Color.Blue:
                    if (current == _blue)
                        break;
                    _blue.SetActive(true);
                    current.SetActive(false);
                    current = _blue;
                    break;
                case Color.Yellow:
                    if (current == _yellow)
                        break;
                    _yellow.SetActive(true);
                    current.SetActive(false);
                    current = _yellow;
                    break;
                case Color.Red:
                    if (current == _red)
                        break;
                    _red.SetActive(true);
                    current.SetActive(false);
                    current = _red;
                    break;
                case Color.Default:
                default:
                    if (current == _default)
                        break;
                    _default.SetActive(true);
                    current.SetActive(false);
                    current = _default;
                    break;
            }
        }
    }
}