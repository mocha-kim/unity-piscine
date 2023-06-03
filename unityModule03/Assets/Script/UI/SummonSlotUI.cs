using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Module02.UI
{
    public class SummonSlotUI : MonoBehaviour
    {
        private float _fixValue = 1.0f / 77.0f;
        private GameObject _canvas;
        private Image _background;
        private Image _portrait;
        
        [SerializeField] private GameObject turretPrefab;

        public int Cost => turretPrefab.GetComponent<Turret>().Cost;

        private void Awake()
        {
            _background = GetComponent<Image>();
            _portrait = transform.GetChild(0).GetComponent<Image>();
            
            var tmp = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            tmp.text = turretPrefab.GetComponent<Turret>().InfoToString();
        }

        private void Start()
        {
            GameManager.Instance.OnEnergyChanged += OnEnergyChanged;
            OnEnergyChanged(GameManager.Instance.Energy);
        }

        private void OnDestroy()
        {
            GameManager.Instance.OnEnergyChanged -= OnEnergyChanged;
        }

        public void SetCanvas(GameObject canvas)
        {
            _canvas = canvas;
        }
        
        public GameObject CreateTurret()
        {
            return GameObject.Instantiate(turretPrefab);
        }
        
        public GameObject CreateTurretImage()
        {
            GameObject turret = new GameObject();
            RectTransform rect = turret.AddComponent<RectTransform>();
            rect.localScale = new Vector3(_fixValue, _fixValue, _fixValue);
            rect.sizeDelta = new Vector2(90.0f, 60.0f);
            turret.transform.SetParent(_canvas.transform);

            Image image = turret.AddComponent<Image>();
            image.sprite = turretPrefab.GetComponent<SpriteRenderer>().sprite;
            image.raycastTarget = false;

            turret.name = "Dragging Item";
            return turret;
        }

        private void OnEnergyChanged(int energy)
        {
            if (energy < Cost)
            {
                _background.color = Color.gray;
                _portrait.color = Color.grey;
                return;
            }
            _background.color = Color.white;
            _portrait.color = Color.white;
        }
    }
}